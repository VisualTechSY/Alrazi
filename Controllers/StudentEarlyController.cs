using Alrazi.Enums;
using Alrazi.Models;
using Alrazi.Services;
using Alrazi.Tools;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Alrazi.Controllers
{
    public class StudentEarlyController : Controller
    {
        private readonly ConfigService configService;
        private readonly StudentService studentService;
        private readonly AccountService accountService;

        public StudentEarlyController(ConfigService configService , StudentService studentService , AccountService accountService)
        {
            this.configService = configService;
            this.accountService = accountService;
            this.studentService = studentService;
        }

        [HttpGet("Add-Student-Development")]
        public IActionResult AddStudentDevelopment()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View(SessionManager.GetStudent<StudentDevelopment>(HttpContext, StudentStatus.Early_StudentDevelopment));
        }

        [HttpPost("Add-Student-Development")]
        public IActionResult AddStudentDevelopment(StudentDevelopment studentDevelopment)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            SessionManager.CreateStudent(HttpContext, studentDevelopment, StudentStatus.Early_StudentDevelopment);
            return Redirect("~/Add-Student-Psychology-Development");
        }

       

        [HttpGet("Add-Student-Autonomy")]
        public IActionResult AddStudentAutonomy()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View(SessionManager.GetStudent<StudentAutonomy>(HttpContext, StudentStatus.Early_StudentAutonomy));
        }

        [HttpPost("Add-Student-Autonomy")]
        public IActionResult AddStudentAutonomy(StudentAutonomy studentAutonomy)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            SessionManager.CreateStudent(HttpContext, studentAutonomy, StudentStatus.Early_StudentAutonomy);
            return Redirect("~/Add-Family-Activity");
        }

        

        [HttpGet("Add-Student-Potential-Enhancer")]
        public IActionResult AddStudentPotentialEnhancer()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View(SessionManager.GetStudent<StudentPotentialEnhancer>(HttpContext, StudentStatus.Early_StudentPotentialEnhancer));
        }

        [HttpPost("Add-Student-Potential-Enhancer")]
        public IActionResult AddStudentPotentialEnhancer(StudentPotentialEnhancer studentPotentialEnhancer)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            SessionManager.CreateStudent(HttpContext, studentPotentialEnhancer, StudentStatus.Early_StudentPotentialEnhancer);
            return Redirect("~/Add-Student-Educationalualification");
        }

        [HttpGet("Add-Student-Educationalualification")]
        public IActionResult AddStudentEducationalualification()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View(SessionManager.GetStudent<List<StudentEducationalualification>>(HttpContext, StudentStatus.Early_StudentEducationalualification));
        }

        [HttpPost("AddStudentEducationalualification")]
        public void AddStudentEducationalualification(StudentEducationalualification studentEducationalualification)
        {
            if (!HttpContext.HasSession())
                return;
            var getData = SessionManager.GetStudent<List<StudentEducationalualification>>(HttpContext, StudentStatus.Early_StudentEducationalualification);
            getData.Add(studentEducationalualification);
            SessionManager.CreateStudent(HttpContext, getData, StudentStatus.Early_StudentEducationalualification);
        }

        [HttpPost("DeleteStudentEducationalualification")]
        public void DeleteStudentEducationalualification(Guid id)
        {
            if (!HttpContext.HasSession())
                return;
            var getData = SessionManager.GetStudent<List<StudentEducationalualification>>(HttpContext, StudentStatus.Early_StudentEducationalualification);
            getData.Remove(getData.First(x => x.UId == id));
            SessionManager.CreateStudent(HttpContext, getData, StudentStatus.Early_StudentEducationalualification);
        }

        [HttpPost("Add-Student-Educationalualification")]
        public IActionResult AddStudentEducationalualification(bool done)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return Redirect("~/Add-Student-Note");
        }

        [HttpGet("Save-Early-Student")]
        public async Task<IActionResult> SaveEarlyStudent()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            var student = SessionManager.GetStudent<Student>(HttpContext, StudentStatus.Student);
            var studentFamilyInfo = SessionManager.GetStudent<StudentFamilyInfo>(HttpContext, StudentStatus.StudentFamilyInfo);
            var studentSiblings = SessionManager.GetStudent<List<StudentSibling>>(HttpContext, StudentStatus.StudentSibling);
            var studentMotherMedical = SessionManager.GetStudent<StudentMotherMedical>(HttpContext, StudentStatus.StudentMotherMedical);
            var studentMedical = SessionManager.GetStudent<StudentMedical>(HttpContext, StudentStatus.StudentMedical);
            var studentMedicalTest = SessionManager.GetStudent<StudentMedicalTest>(HttpContext, StudentStatus.StudentMedicalTest);
            var studentDevelopment = SessionManager.GetStudent<StudentDevelopment>(HttpContext, StudentStatus.Early_StudentDevelopment);
            var studentPsychologyDevelopment = SessionManager.GetStudent<StudentPsychologyDevelopment>(HttpContext, StudentStatus.StudentPsychologyDevelopment);
            var studentSocialDevelopment = SessionManager.GetStudent<StudentSocialDevelopment>(HttpContext, StudentStatus.StudentSocialDevelopment);
            var studentAutonomy = SessionManager.GetStudent<StudentAutonomy>(HttpContext, StudentStatus.Early_StudentAutonomy);
            var studentFamilyActivity = SessionManager.GetStudent<StudentFamilyActivity>(HttpContext, StudentStatus.StudentFamilyActivity);
            var studentPotentialEnhancer = SessionManager.GetStudent<StudentPotentialEnhancer>(HttpContext, StudentStatus.Early_StudentPotentialEnhancer);
            var studentEducationalualifications = SessionManager.GetStudent<List<StudentEducationalualification>>(HttpContext, StudentStatus.Early_StudentEducationalualification);
            var studentNote = SessionManager.GetStudent<StudentNote>(HttpContext, StudentStatus.StudentNote);

            student.StudentStatus = StudentStatus.Early;

            await studentService.AddEarlyStudent(student, studentFamilyInfo, studentSiblings, studentMotherMedical, studentMedical,
                studentMedicalTest, studentDevelopment, studentPsychologyDevelopment, studentSocialDevelopment, studentAutonomy,
                studentFamilyActivity, studentPotentialEnhancer, studentEducationalualifications, studentNote);

            var getAccount = await accountService.GetAccount(HttpContext.GetMyId());
            HttpContext.Session.Clear();
            HttpContext.SetSession(getAccount);

            return View();
        }

        [HttpGet("Edit-Early-Student/{id}")]
        public async Task<IActionResult> EditEarlyStudent(int id)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            var getConfigs = await configService.GetConfigs();

            var earlyRange = getConfigs.First(x => x.ConfigKey == ConfigKey.EarlyRange).Value.Split('-');
            var lDRange = getConfigs.First(x => x.ConfigKey == ConfigKey.LDRange).Value.Split('-');
            var eQRange = getConfigs.First(x => x.ConfigKey == ConfigKey.EQRange).Value.Split('-');

            ViewBag.EarlyMin = earlyRange[0];
            ViewBag.EarlyMax = earlyRange[1];

            ViewBag.LDMin = lDRange[0];
            ViewBag.LDMax = lDRange[1];

            ViewBag.EQMin = eQRange[0];
            ViewBag.EQMax = eQRange[1];
            ViewData["Nationalities"] = await configService.GetNationalities();
            ViewData["AccessChannels"] = await configService.GetAccessChannels();
            ViewData["Diagnoses"] = await configService.GetDiagnoses();
            ViewData["BehavioralProblems"] = await configService.GetBehavioralProblems();
            return View(await studentService.EditEarlyStudent(id));
        }

        [HttpPost("EditStudent")]
        public async Task<IActionResult> EditStudent(Student student)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            await studentService.EditStudent(student);
            return Redirect("Edit-Early-Student/" + student.Id);
        }

        [HttpPost("EditStudentFamilyInfo")]
        public async Task<IActionResult> EditStudentFamilyInfo(StudentFamilyInfo studentFamilyInfo)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            studentFamilyInfo.MotherBirthDate = new DateTime(DateTime.Now.Year - studentFamilyInfo.MotherYear, 1, 1);
            studentFamilyInfo.FatherBirthDate = new DateTime(DateTime.Now.Year - studentFamilyInfo.FatherYear, 1, 1);
            await studentService.EditStudentFamilyInfo(studentFamilyInfo);
            return Redirect("Edit-Early-Student/" + studentFamilyInfo.Id);
        }

        [HttpPost("AddNewStudentSibling")]
        public async Task<IActionResult> AddNewStudentSibling(int studentId, int age, int order, string name, bool isMale,
            string level)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            await studentService.AddNewStudentSibling(new StudentSibling
            {
                BirthDate = new DateTime(DateTime.Now.Year, 1, 1).AddYears(-age),
                FullName = name,
                IsMale = isMale,
                Order = order,
                StudentId = studentId,
                StudyLevel = level,
            });
            return Redirect("Edit-Early-Student/" + studentId);
        }

        [HttpGet("RemoveStudentSibling/{id}")]
        public async Task<IActionResult> RemoveStudentSibling(int id)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            var studentId = await studentService.RemoveStudentSibling(id);
            return Redirect("~/Edit-Early-Student/" + studentId);
        }

        [HttpPost("EditStudentMotherMedical")]
        public async Task<IActionResult> EditStudentMotherMedical(StudentMotherMedical studentMotherMedical)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            studentMotherMedical.MotherAgeAtBirth = new DateTime(DateTime.Now.Year - studentMotherMedical.MotherAtBirthYear, 1, 1);
            await studentService.EditStudentMotherMedical(studentMotherMedical);
            return Redirect("Edit-Early-Student/" + studentMotherMedical.Id);
        }

        [HttpPost("EditStudentMedical")]
        public async Task<IActionResult> EditStudentMedical(StudentMedical studentMedical)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            await studentService.EditStudentMedical(studentMedical);
            return Redirect("Edit-Early-Student/" + studentMedical.Id);
        }

        [HttpPost("EditStudentMedicalTest")]
        public async Task<IActionResult> EditStudentMedicalTest(StudentMedicalTest studentMedicalTest)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            await studentService.EditStudentMedicalTest(studentMedicalTest);
            return Redirect("Edit-Early-Student/" + studentMedicalTest.Id);
        }

        [HttpPost("EditStudentDevelopment")]
        public async Task<IActionResult> EditStudentDevelopment(StudentDevelopment studentDevelopment)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            await studentService.EditStudentDevelopment(studentDevelopment);
            return Redirect("Edit-Early-Student/" + studentDevelopment.Id);
        }

        [HttpPost("EditStudentPsychologyDevelopment")]
        public async Task<IActionResult> EditStudentPsychologyDevelopment(StudentPsychologyDevelopment studentPsychologyDevelopment)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            await studentService.EditStudentPsychologyDevelopment(studentPsychologyDevelopment);
            return Redirect("Edit-Early-Student/" + studentPsychologyDevelopment.Id);
        }

        [HttpPost("EditStudentSocialDevelopment")]
        public async Task<IActionResult> EditStudentPsychologyDevelopment(StudentSocialDevelopment studentSocialDevelopment)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            await studentService.EditStudentSocialDevelopment(studentSocialDevelopment);
            return Redirect("Edit-Early-Student/" + studentSocialDevelopment.Id);
        }

        [HttpPost("EditStudentAutonomy")]
        public async Task<IActionResult> EditStudentAutonomy(StudentAutonomy studentAutonomy)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            await studentService.EditStudentAutonomy(studentAutonomy);
            return Redirect("Edit-Early-Student/" + studentAutonomy.Id);
        }

        [HttpPost("EditStudentFamilyActivity")]
        public async Task<IActionResult> EditStudentFamilyActivity(StudentFamilyActivity studentFamilyActivity)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            await studentService.EditStudentFamilyActivity(studentFamilyActivity);
            return Redirect("Edit-Early-Student/" + studentFamilyActivity.Id);
        }

        [HttpPost("EditStudentPotentialEnhancer")]
        public async Task<IActionResult> EditStudentPotentialEnhancer(StudentPotentialEnhancer studentPotentialEnhancer)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            await studentService.EditStudentPotentialEnhancer(studentPotentialEnhancer);
            return Redirect("Edit-Early-Student/" + studentPotentialEnhancer.Id);
        }

        [HttpPost("AddNewStudentEducationalualification")]
        public async Task<IActionResult> AddNewStudentEducationalualification(int studentId, string centerName, string diagnosis,
            string specialist, string rehabilitation, string rehabilitationAxes, string duration)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            await studentService.AddNewStudentEducationalualification(new StudentEducationalualification
            {
                StudentId = studentId,
                CenterName = centerName,
                Diagnosis = diagnosis,
                Specialist = specialist,
                Rehabilitation = rehabilitation,
                RehabilitationAxes = rehabilitationAxes,
                Duration = duration
            });
            return Redirect("Edit-Early-Student/" + studentId);
        }

        [HttpGet("RemoveStudentEducationalualification/{id}")]
        public async Task<IActionResult> RemoveStudentEducationalualification(int id)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            var studentId = await studentService.RemoveStudentEducationalualification(id);
            return Redirect("~/Edit-Early-Student/" + studentId);
        }

        [HttpPost("EditStudentNote")]
        public async Task<IActionResult> EditStudentNote(StudentNote studentNote)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            await studentService.EditStudentNote(studentNote);
            return Redirect("Edit-Early-Student/" + studentNote.Id);
        }


    }
}