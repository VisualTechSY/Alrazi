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

        public StudentEarlyController(ConfigService configService , StudentService studentService)
        {
            this.configService = configService;
            this.studentService = studentService;
        }

        [HttpGet("Add-Student-Family-Info")]
        public IActionResult AddStudentFamilyInfo()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View(SessionManager.GetStudent<StudentFamilyInfo>(HttpContext, StudentStatus.Early_StudentFamilyInfo));
        }

        [HttpPost("Add-Student-Family-Info")]
        public IActionResult AddStudentFamilyInfo(StudentFamilyInfo studentFamilyInfo)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            studentFamilyInfo.MotherBirthDate = new DateTime(DateTime.Now.Year - studentFamilyInfo.MotherYear, 1, 1);
            studentFamilyInfo.FatherBirthDate = new DateTime(DateTime.Now.Year - studentFamilyInfo.FatherYear, 1, 1);
            studentFamilyInfo.MotherAgeAtBirth = new DateTime(DateTime.Now.Year - studentFamilyInfo.MotherAtBirthYear, 1, 1);

            SessionManager.CreateStudent(HttpContext, studentFamilyInfo, StudentStatus.Early_StudentFamilyInfo);
            return Redirect("~/Add-Student-Sibling");
        }

        [HttpGet("Add-Student-Sibling")]
        public IActionResult AddStudentSibling()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View(SessionManager.GetStudent<List<StudentSibling>>(HttpContext, StudentStatus.Early_StudentSibling));
        }

        [HttpPost("AddSiblingRecord")]
        public void AddSiblingRecord(int order, string name, bool isMale, int age, string level)
        {
            if (!HttpContext.HasSession())
                return;
            var getData = SessionManager.GetStudent<List<StudentSibling>>(HttpContext, StudentStatus.Early_StudentSibling);
            getData.Add(new StudentSibling
            {
                BirthDate = new DateTime(DateTime.Now.Year , 1 , 1).AddYears(-age),
                FullName = name,
                IsMale = isMale,
                Order = order,
                StudyLevel = level
            });
            SessionManager.CreateStudent(HttpContext, getData, StudentStatus.Early_StudentSibling);
        }

        [HttpPost("DeleteSiblingRecord")]
        public void DeleteSiblingRecord(Guid id)
        {
            if (!HttpContext.HasSession())
                return;
            var getData = SessionManager.GetStudent<List<StudentSibling>>(HttpContext, StudentStatus.Early_StudentSibling);
            getData.Remove(getData.First(x=> x.UId == id));
            SessionManager.CreateStudent(HttpContext, getData, StudentStatus.Early_StudentSibling);
        }

        [HttpPost("Add-Student-Sibling")]
        public IActionResult AddStudentSibling(bool done)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return Redirect("~/Add-Student-Mother-Medical");
        }

        [HttpGet("Add-Student-Mother-Medical")]
        public IActionResult AddStudentMotherMedical()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View(SessionManager.GetStudent<StudentMotherMedical>(HttpContext, StudentStatus.Early_StudentMotherMedical));
        }

        [HttpPost("Add-Student-Mother-Medical")]
        public IActionResult AddStudentMotherMedical(StudentMotherMedical studentMotherMedical)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            SessionManager.CreateStudent(HttpContext, studentMotherMedical, StudentStatus.Early_StudentMotherMedical);
            return Redirect("~/Add-Student-Medical");
        }

        [HttpGet("Add-Student-Medical")]
        public IActionResult AddStudentMedical()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View(SessionManager.GetStudent<StudentMedical>(HttpContext, StudentStatus.Early_StudentMedical));
        }

        [HttpPost("Add-Student-Medical")]
        public IActionResult AddStudentMedical(StudentMedical studentMedical)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            SessionManager.CreateStudent(HttpContext, studentMedical, StudentStatus.Early_StudentMedical);
            return Redirect("~/Add-Student-Medical-Test");
        }

        [HttpGet("Add-Student-Medical-Test")]
        public IActionResult AddStudentMedicalTest()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View(SessionManager.GetStudent<StudentMedicalTest>(HttpContext, StudentStatus.Early_StudentMedicalTest));
        }

        [HttpPost("Add-Student-Medical-Test")]
        public IActionResult AddStudentMedicalTest(StudentMedicalTest studentMedicalTest)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            SessionManager.CreateStudent(HttpContext, studentMedicalTest, StudentStatus.Early_StudentMedicalTest);
            return Redirect("~/Add-Student-Development");
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

        [HttpGet("Add-Student-Psychology-Development")]
        public async Task<IActionResult> AddStudentPsychologyDevelopment()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            ViewData["BehavioralProblems"] = (await configService.GetBehavioralProblems()).Where(x=> x.IsActive).ToList();
            var getData = SessionManager.GetStudent<StudentPsychologyDevelopment>(HttpContext, StudentStatus.Early_StudentPsychologyDevelopment);
            if (getData.StudentPsychologyDevelopmentBehavioralProblems is null)
                getData.StudentPsychologyDevelopmentBehavioralProblems = new();
            return View(getData);
        }

        [HttpPost("Add-Student-Psychology-Development")]
        public IActionResult AddStudentPsychologyDevelopment(StudentPsychologyDevelopment studentPsychologyDevelopment , int[] BehavioralProblems)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            studentPsychologyDevelopment.StudentPsychologyDevelopmentBehavioralProblems = new List<StudentPsychologyDevelopmentBehavioralProblem>();
            foreach (var item in BehavioralProblems)
            {
                studentPsychologyDevelopment.StudentPsychologyDevelopmentBehavioralProblems.Add(new StudentPsychologyDevelopmentBehavioralProblem
                {
                    BehavioralProblemId = item
                });
            }
            SessionManager.CreateStudent(HttpContext, studentPsychologyDevelopment, StudentStatus.Early_StudentPsychologyDevelopment);
            return Redirect("~/Add-Student-Social-Development");
        }

        [HttpGet("Add-Student-Social-Development")]
        public IActionResult AddStudentSocialDevelopment()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View(SessionManager.GetStudent<StudentSocialDevelopment>(HttpContext, StudentStatus.Early_StudentSocialDevelopment));
        }

        [HttpPost("Add-Student-Social-Development")]
        public IActionResult AddStudentSocialDevelopment(StudentSocialDevelopment studentSocialDevelopment)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            SessionManager.CreateStudent(HttpContext, studentSocialDevelopment, StudentStatus.Early_StudentSocialDevelopment);
            return Redirect("~/Add-Student-Autonomy");
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

        [HttpGet("Add-Family-Activity")]
        public IActionResult AddFamilyActivity()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View(SessionManager.GetStudent<StudentFamilyActivity>(HttpContext, StudentStatus.Early_StudentFamilyActivity));
        }

        [HttpPost("Add-Family-Activity")]
        public IActionResult AddFamilyActivity(StudentFamilyActivity studentFamilyActivity)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            SessionManager.CreateStudent(HttpContext, studentFamilyActivity, StudentStatus.Early_StudentFamilyActivity);
            return Redirect("~/Add-Student-Potential-Enhancer");
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

        [HttpGet("Add-Student-Note")]
        public IActionResult AddStudentNote()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View(SessionManager.GetStudent<StudentNote>(HttpContext, StudentStatus.Early_StudentNote));
        }

        [HttpPost("Add-Student-Note")]
        public IActionResult AddStudentNote(StudentNote studentNote)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            SessionManager.CreateStudent(HttpContext, studentNote, StudentStatus.Early_StudentNote);
            return Redirect("~/Save-Student");
        }

        [HttpGet("Save-Student")]
        public async Task<IActionResult> SaveStudent()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            var student = SessionManager.GetStudent<Student>(HttpContext, StudentStatus.Early_Student);
            var studentFamilyInfo = SessionManager.GetStudent<StudentFamilyInfo>(HttpContext, StudentStatus.Early_StudentFamilyInfo);
            var studentSiblings = SessionManager.GetStudent<List<StudentSibling>>(HttpContext, StudentStatus.Early_StudentSibling);
            var studentMotherMedical = SessionManager.GetStudent<StudentMotherMedical>(HttpContext, StudentStatus.Early_StudentMotherMedical);
            var studentMedical = SessionManager.GetStudent<StudentMedical>(HttpContext, StudentStatus.Early_StudentMedical);
            var studentMedicalTest = SessionManager.GetStudent<StudentMedicalTest>(HttpContext, StudentStatus.Early_StudentMedicalTest);
            var studentDevelopment = SessionManager.GetStudent<StudentDevelopment>(HttpContext, StudentStatus.Early_StudentDevelopment);
            var studentPsychologyDevelopment = SessionManager.GetStudent<StudentPsychologyDevelopment>(HttpContext, StudentStatus.Early_StudentPsychologyDevelopment);
            var studentSocialDevelopment = SessionManager.GetStudent<StudentSocialDevelopment>(HttpContext, StudentStatus.Early_StudentSocialDevelopment);
            var studentAutonomy = SessionManager.GetStudent<StudentAutonomy>(HttpContext, StudentStatus.Early_StudentAutonomy);
            var studentFamilyActivity = SessionManager.GetStudent<StudentFamilyActivity>(HttpContext, StudentStatus.Early_StudentFamilyActivity);
            var studentPotentialEnhancer = SessionManager.GetStudent<StudentPotentialEnhancer>(HttpContext, StudentStatus.Early_StudentPotentialEnhancer);
            var studentEducationalualifications = SessionManager.GetStudent<List<StudentEducationalualification>>(HttpContext, StudentStatus.Early_StudentEducationalualification);
            var studentNote = SessionManager.GetStudent<StudentNote>(HttpContext, StudentStatus.Early_StudentNote);
            await studentService.AddEarlyStudent(student, studentFamilyInfo, studentSiblings, studentMotherMedical, studentMedical,
                studentMedicalTest, studentDevelopment, studentPsychologyDevelopment, studentSocialDevelopment, studentAutonomy,
                studentFamilyActivity, studentPotentialEnhancer, studentEducationalualifications, studentNote);
            return View();
        }
    }
}