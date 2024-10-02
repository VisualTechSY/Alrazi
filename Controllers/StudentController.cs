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

        public StudentController(AccountService accountService, ConfigService configService)
        {
            this.accountService = accountService;
            this.configService = configService;
        }

        [HttpGet("Add-Student")]
        public async Task<IActionResult> AddStudent()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            ViewData["Nationalities"] = (await configService.GetNationalities()).Where(x => x.IsActive).ToList();
            ViewData["AccessChannels"] = (await configService.GetAccessChannels()).Where(x => x.IsActive).ToList();
            ViewData["Diagnoses"] = (await configService.GetDiagnoses()).Where(x => x.IsActive).ToList();

            return SessionManager.GetStudentType(HttpContext) switch
            {
                StudentType.StudentEarly => View(SessionManager.GetStudent<Student>(HttpContext, StudentStatus.Early_Student)),
                StudentType.StudentLearningDifficulties => View(SessionManager.GetStudent<Student>(HttpContext, StudentStatus.LD_Student)),
                _ => View(new Student()),
            };
        }

        [HttpPost("Add-Student")]
        public async Task<IActionResult> AddStudent(Student student)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            var configAge = (await configService.GetConfigs()).First(x => x.ConfigKey == ConfigKey.MinStudyDate).Value;
            if (student.GetAge() > Convert.ToInt16(configAge))
            {
                SessionManager.SetStudentType(HttpContext, StudentType.StudentLearningDifficulties);
                SessionManager.CreateStudent(HttpContext, student, StudentStatus.LD_Student);
            }
            else
            {
                SessionManager.SetStudentType(HttpContext, StudentType.StudentEarly);
                SessionManager.CreateStudent(HttpContext, student, StudentStatus.Early_Student);
            }
            return Redirect("~/Add-Student-Family-Info");
        }

        [HttpGet("Add-Student-Family-Info")]
        public IActionResult AddStudentFamilyInfo()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            ViewBag.StudentType = SessionManager.GetStudentType(HttpContext);

            return ViewBag.StudentType switch
            {
                StudentType.StudentEarly => View(SessionManager.GetStudent<StudentFamilyInfo>(HttpContext, StudentStatus.Early_StudentFamilyInfo)),
                StudentType.StudentLearningDifficulties => View(SessionManager.GetStudent<StudentFamilyInfo>(HttpContext, StudentStatus.LD_StudentFamilyInfo)),
                _ => View(RedirectToAction("Index")),
            };
        }

        [HttpPost("Add-Student-Family-Info")]
        public IActionResult AddStudentFamilyInfo(StudentFamilyInfo studentFamilyInfo)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            studentFamilyInfo.MotherBirthDate = new DateTime(DateTime.Now.Year - studentFamilyInfo.MotherYear, 1, 1);
            studentFamilyInfo.FatherBirthDate = new DateTime(DateTime.Now.Year - studentFamilyInfo.FatherYear, 1, 1);
            studentFamilyInfo.MotherAgeAtBirth = new DateTime(DateTime.Now.Year - studentFamilyInfo.MotherAtBirthYear, 1, 1);

            if (SessionManager.GetStudentType(HttpContext) == StudentType.StudentEarly)
                SessionManager.CreateStudent(HttpContext, studentFamilyInfo, StudentStatus.Early_StudentFamilyInfo);
            else if (SessionManager.GetStudentType(HttpContext) == StudentType.StudentLearningDifficulties)
                SessionManager.CreateStudent(HttpContext, studentFamilyInfo, StudentStatus.LD_StudentFamilyInfo);

            return Redirect("~/Add-Student-Sibling");
        }


        [HttpGet("Add-Student-Sibling")]
        public IActionResult AddStudentSibling()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            ViewBag.StudentType = SessionManager.GetStudentType(HttpContext);

            return ViewBag.StudentType switch
            {
                StudentType.StudentEarly => View(SessionManager.GetStudent<StudentFamilyInfo>(HttpContext, StudentStatus.Early_StudentFamilyInfo)),
                StudentType.StudentLearningDifficulties => View(SessionManager.GetStudent<StudentFamilyInfo>(HttpContext, StudentStatus.LD_StudentFamilyInfo)),
                _ => View(RedirectToAction("Index")),
            };

        }

        [HttpPost("AddSiblingRecord")]
        public void AddSiblingRecord(int order, string name, bool isMale, int age, string level, string healthStatus = "")
        {
            if (!HttpContext.HasSession())
                return;
            List<StudentSibling> getData = [];
            if (SessionManager.GetStudentType(HttpContext) == StudentType.StudentEarly)
                getData = SessionManager.GetStudent<List<StudentSibling>>(HttpContext, StudentStatus.Early_StudentSibling);
            else if (SessionManager.GetStudentType(HttpContext) == StudentType.StudentLearningDifficulties)
                getData = SessionManager.GetStudent<List<StudentSibling>>(HttpContext, StudentStatus.LD_StudentSibling);

            getData.Add(new StudentSibling
            {
                BirthDate = new DateTime(DateTime.Now.Year, 1, 1).AddYears(-age),
                FullName = name,
                IsMale = isMale,
                Order = order,
                HealthStatus = healthStatus,
                StudyLevel = level
            });

            if (SessionManager.GetStudentType(HttpContext) == StudentType.StudentEarly)
                SessionManager.CreateStudent(HttpContext, getData, StudentStatus.Early_StudentSibling);
            else if (SessionManager.GetStudentType(HttpContext) == StudentType.StudentLearningDifficulties)
                SessionManager.CreateStudent(HttpContext, getData, StudentStatus.LD_StudentSibling);

        }

        [HttpPost("DeleteSiblingRecord")]
        public void DeleteSiblingRecord(Guid id)
        {
            if (!HttpContext.HasSession())
                return;
            List<StudentSibling> getData = [];
            if (SessionManager.GetStudentType(HttpContext) == StudentType.StudentEarly)
                getData = SessionManager.GetStudent<List<StudentSibling>>(HttpContext, StudentStatus.Early_StudentSibling);
            else if (SessionManager.GetStudentType(HttpContext) == StudentType.StudentLearningDifficulties)
                getData = SessionManager.GetStudent<List<StudentSibling>>(HttpContext, StudentStatus.LD_StudentSibling);

            getData.Remove(getData.First(x => x.UId == id));

            if (SessionManager.GetStudentType(HttpContext) == StudentType.StudentEarly)
                SessionManager.CreateStudent(HttpContext, getData, StudentStatus.Early_StudentSibling);
            else if (SessionManager.GetStudentType(HttpContext) == StudentType.StudentLearningDifficulties)
                SessionManager.CreateStudent(HttpContext, getData, StudentStatus.LD_StudentSibling);

        }

        [HttpPost("Add-Student-Sibling")]
        public IActionResult AddStudentSibling(bool done)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            if (SessionManager.GetStudentType(HttpContext) == StudentType.StudentEarly)
                return Redirect("~/Add-Student-Mother-Medical");
            else if (SessionManager.GetStudentType(HttpContext) == StudentType.StudentLearningDifficulties)
                return RedirectToAction("Index");
            else
                return RedirectToAction("Index");

        }
    }
}