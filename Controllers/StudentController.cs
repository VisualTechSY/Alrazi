using Alrazi.Enums;
using Alrazi.Models;
using Alrazi.Services;
using Alrazi.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace Alrazi.Controllers
{
    public class StudentController : Controller
    {
        private readonly AccountService accountService;
        private readonly ConfigService configService;
        private readonly StudentService studentService;

        public StudentController(AccountService accountService, ConfigService configService , StudentService studentService)
        {
            this.accountService = accountService;
            this.configService = configService;
            this.studentService = studentService;
        }

        [HttpGet("Add-Student")]
        public async Task<IActionResult> AddStudent()
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

            ViewData["Nationalities"] = (await configService.GetNationalities()).Where(x => x.IsActive).ToList();
            ViewData["AccessChannels"] = (await configService.GetAccessChannels()).Where(x => x.IsActive).ToList();
            ViewData["Diagnoses"] = (await configService.GetDiagnoses()).Where(x => x.IsActive).ToList();

            return View(SessionManager.GetStudent<Student>(HttpContext, StudentStatus.Student));
        }

        [HttpPost("Add-Student")]
        public async Task<IActionResult> AddStudent(Student student)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            var getConfigs = await configService.GetConfigs();

            var earlyRange = getConfigs.First(x => x.ConfigKey == ConfigKey.EarlyRange).Value.Split('-');
            var lDRange = getConfigs.First(x => x.ConfigKey == ConfigKey.LDRange).Value.Split('-');
            var eQRange = getConfigs.First(x => x.ConfigKey == ConfigKey.EQRange).Value.Split('-');


            if (student.GetAge() >= Convert.ToInt16(lDRange[0]) && student.GetAge() <= Convert.ToInt16(lDRange[1]))
                SessionManager.SetStudentType(HttpContext, StudentType.StudentLearningDifficulties);
            else
                SessionManager.SetStudentType(HttpContext, StudentType.StudentEarly);

            SessionManager.CreateStudent(HttpContext, student, StudentStatus.Student);
            return Redirect("~/Add-Student-Family-Info");
        }

        [HttpGet("Add-Student-Family-Info")]
        public IActionResult AddStudentFamilyInfo()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            ViewBag.StudentType = SessionManager.GetStudentType(HttpContext);

            return View(SessionManager.GetStudent<StudentFamilyInfo>(HttpContext, StudentStatus.StudentFamilyInfo));
        }

        [HttpPost("Add-Student-Family-Info")]
        public IActionResult AddStudentFamilyInfo(StudentFamilyInfo studentFamilyInfo)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            studentFamilyInfo.MotherBirthDate = new DateTime(DateTime.Now.Year - studentFamilyInfo.MotherYear, 1, 1);
            studentFamilyInfo.FatherBirthDate = new DateTime(DateTime.Now.Year - studentFamilyInfo.FatherYear, 1, 1);

            ViewBag.StudentType = SessionManager.GetStudentType(HttpContext);

            SessionManager.CreateStudent(HttpContext, studentFamilyInfo, StudentStatus.StudentFamilyInfo);

            return Redirect("~/Add-Student-Sibling");
        }


        [HttpGet("Add-Student-Sibling")]
        public IActionResult AddStudentSibling()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            ViewBag.StudentType = SessionManager.GetStudentType(HttpContext);
            return View(SessionManager.GetStudent<List<StudentSibling>>(HttpContext, StudentStatus.StudentSibling));

        }

        [HttpPost("AddSiblingRecord")]
        public void AddSiblingRecord(int order, string name, bool isMale, int age, string level, string healthStatus = "")
        {
            if (!HttpContext.HasSession())
                return;
            List<StudentSibling> getData = [];
            getData = SessionManager.GetStudent<List<StudentSibling>>(HttpContext, StudentStatus.StudentSibling);

            getData.Add(new StudentSibling
            {
                BirthDate = new DateTime(DateTime.Now.Year, 1, 1).AddYears(-age),
                FullName = name,
                IsMale = isMale,
                Order = order,
                HealthStatus = healthStatus,
                StudyLevel = level
            });

            SessionManager.CreateStudent(HttpContext, getData, StudentStatus.StudentSibling);
        }

        [HttpPost("DeleteSiblingRecord")]
        public void DeleteSiblingRecord(Guid id)
        {
            if (!HttpContext.HasSession())
                return;
            List<StudentSibling> getData = [];
            getData = SessionManager.GetStudent<List<StudentSibling>>(HttpContext, StudentStatus.StudentSibling);

            getData.Remove(getData.First(x => x.UId == id));

            SessionManager.CreateStudent(HttpContext, getData, StudentStatus.StudentSibling);

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

            ViewBag.StudentType = SessionManager.GetStudentType(HttpContext);

            return View(SessionManager.GetStudent<StudentMotherMedical>(HttpContext, StudentStatus.StudentMotherMedical));
        }

        [HttpPost("Add-Student-Mother-Medical")]
        public IActionResult AddStudentMotherMedical(StudentMotherMedical studentMotherMedical)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            studentMotherMedical.MotherAgeAtBirth = new DateTime(DateTime.Now.Year - studentMotherMedical.MotherAtBirthYear, 1, 1);
            SessionManager.CreateStudent(HttpContext, studentMotherMedical, StudentStatus.StudentMotherMedical);
            return Redirect("~/Add-Student-Medical");
        }

        [HttpGet("Add-Student-Medical")]
        public IActionResult AddStudentMedical()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            ViewBag.StudentType = SessionManager.GetStudentType(HttpContext);

            return View(SessionManager.GetStudent<StudentMedical>(HttpContext, StudentStatus.StudentMedical));
        }

        [HttpPost("Add-Student-Medical")]
        public IActionResult AddStudentMedical(StudentMedical studentMedical)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            SessionManager.CreateStudent(HttpContext, studentMedical, StudentStatus.StudentMedical);
            return Redirect("~/Add-Student-Medical-Test");
        }

        [HttpGet("Add-Student-Medical-Test")]
        public IActionResult AddStudentMedicalTest()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            ViewBag.StudentType = SessionManager.GetStudentType(HttpContext);

            return View(SessionManager.GetStudent<StudentMedicalTest>(HttpContext, StudentStatus.StudentMedicalTest));
        }

        [HttpPost("Add-Student-Medical-Test")]
        public IActionResult AddStudentMedicalTest(StudentMedicalTest studentMedicalTest)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            SessionManager.CreateStudent(HttpContext, studentMedicalTest, StudentStatus.StudentMedicalTest);
            var getStudentType = SessionManager.GetStudentType(HttpContext);
            if (getStudentType == StudentType.StudentEarly)
                return Redirect("~/Add-Student-Development");
            return Redirect("~/Add-Student-Psychology-Development");
        }

        [HttpGet("Add-Student-Psychology-Development")]
        public async Task<IActionResult> AddStudentPsychologyDevelopment()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            var studentType = SessionManager.GetStudentType(HttpContext);

            ViewBag.StudentType = studentType;

            ViewData["BehavioralProblems"] = (await configService.GetBehavioralProblems()).Where(x => x.IsActive).ToList();

            var getData = SessionManager.GetStudent<StudentPsychologyDevelopment>(HttpContext, StudentStatus.StudentPsychologyDevelopment);
            if (getData.StudentPsychologyDevelopmentBehavioralProblems is null)
                getData.StudentPsychologyDevelopmentBehavioralProblems = [];


            return View(getData);
        }

        [HttpPost("Add-Student-Psychology-Development")]
        public IActionResult AddStudentPsychologyDevelopment(StudentPsychologyDevelopment studentPsychologyDevelopment, int[] BehavioralProblems)
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
            SessionManager.CreateStudent(HttpContext, studentPsychologyDevelopment, StudentStatus.StudentPsychologyDevelopment);
            var studentType = SessionManager.GetStudentType(HttpContext);

            return Redirect("~/Add-Student-Social-Development");
        }

        [HttpGet("Add-Student-Social-Development")]
        public IActionResult AddStudentSocialDevelopment()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            ViewBag.StudentType = SessionManager.GetStudentType(HttpContext);
            return View(SessionManager.GetStudent<StudentSocialDevelopment>(HttpContext, StudentStatus.StudentSocialDevelopment));
        }

        [HttpPost("Add-Student-Social-Development")]
        public IActionResult AddStudentSocialDevelopment(StudentSocialDevelopment studentSocialDevelopment)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            SessionManager.CreateStudent(HttpContext, studentSocialDevelopment, StudentStatus.StudentSocialDevelopment);

            var studentType = SessionManager.GetStudentType(HttpContext);
            if (studentType == StudentType.StudentEarly)
                return Redirect("~/Add-Student-Autonomy");
            return Redirect("~/Add-Family-Activity");
        }

        [HttpGet("Add-Family-Activity")]
        public IActionResult AddFamilyActivity()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            ViewBag.StudentType = SessionManager.GetStudentType(HttpContext);
            return View(SessionManager.GetStudent<StudentFamilyActivity>(HttpContext, StudentStatus.StudentFamilyActivity));
        }

        [HttpPost("Add-Family-Activity")]
        public IActionResult AddFamilyActivity(StudentFamilyActivity studentFamilyActivity)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            SessionManager.CreateStudent(HttpContext, studentFamilyActivity, StudentStatus.StudentFamilyActivity);
            var studentType = SessionManager.GetStudentType(HttpContext);

            if (studentType == StudentType.StudentEarly)
                return Redirect("~/Add-Student-Potential-Enhancer");

            return Redirect("~/Add-Student-Interests");
        }

        [HttpGet("Add-Student-Note")]
        public IActionResult AddStudentNote()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            ViewBag.StudentType = SessionManager.GetStudentType(HttpContext);
            return View(SessionManager.GetStudent<StudentNote>(HttpContext, StudentStatus.StudentNote));
        }

        [HttpPost("Add-Student-Note")]
        public IActionResult AddStudentNote(StudentNote studentNote)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            SessionManager.CreateStudent(HttpContext, studentNote, StudentStatus.StudentNote);

            var studentType = SessionManager.GetStudentType(HttpContext);
            if (studentType == StudentType.StudentEarly)
                return Redirect("~/Save-Early-Student");

            return Redirect("~/Save-LD-Student");

        }

        [HttpGet("Get-Students")]
        public async Task<IActionResult> GetStudents(int year , StudentStatus studentStatus)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            int startingYear = await studentService.GetStartYear();

            if (startingYear == 0)
                startingYear = DateTime.Now.Year;

            if (studentStatus == 0)
                studentStatus = StudentStatus.Early;
            if (year == 0)
                year = startingYear;

            ViewBag.StartingYear = startingYear;


            ViewBag.StudentStatus = studentStatus;
            ViewBag.Year = year;
            return View(await studentService.GetStudentsInfo(year , studentStatus));
        }
    }
}