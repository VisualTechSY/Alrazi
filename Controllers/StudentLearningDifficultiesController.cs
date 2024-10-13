using Alrazi.Enums;
using Alrazi.Models;
using Alrazi.Services;
using Alrazi.Tools;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Alrazi.Controllers
{
    public class StudentLearningDifficultiesController : Controller
    {
        private readonly ConfigService configService;
        private readonly StudentService studentService;
        private readonly AccountService accountService;

        public StudentLearningDifficultiesController(ConfigService configService , StudentService studentService, AccountService accountService)
        {
            this.configService = configService;
            this.accountService = accountService;
            this.studentService = studentService;
        }

        [HttpGet("Add-Student-Interests")]
        public IActionResult AddStudentInterests()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            var getData = SessionManager.GetStudent<List<StudentInterests>>(HttpContext, StudentStatus.LD_StudentInterests);
            return View(getData);
        }

        [HttpPost("AddInterestsRecord")]
        public void AddSiblingRecord(Interests interests, string name)
        {
            if (!HttpContext.HasSession())
                return;
            List<StudentInterests> getData = [];
            getData = SessionManager.GetStudent<List<StudentInterests>>(HttpContext, StudentStatus.LD_StudentInterests);

            getData.Add(new StudentInterests
            {
                Interests = interests,
                Value = name
            });

            SessionManager.CreateStudent(HttpContext, getData, StudentStatus.LD_StudentInterests);
        }

        [HttpPost("DeleteInterestsRecord")]
        public void DeleteSiblingRecord(Guid id)
        {
            if (!HttpContext.HasSession())
                return;
            List<StudentInterests> getData = [];
            getData = SessionManager.GetStudent<List<StudentInterests>>(HttpContext, StudentStatus.LD_StudentInterests);

            getData.Remove(getData.First(x => x.UId == id));

            SessionManager.CreateStudent(HttpContext, getData, StudentStatus.LD_StudentInterests);

        }

        [HttpPost("Add-Student-Interests")]
        public IActionResult AddStudentInterests(bool done)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            return Redirect("~/Add-Student-Academic");

        }

        [HttpGet("Add-Student-Academic")]
        public IActionResult AddStudentAcademic()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            return View(SessionManager.GetStudent<StudentAcademic>(HttpContext, StudentStatus.LD_StudentAcademic));
        }

        [HttpPost("Add-Student-Academic")]
        public async Task<IActionResult> AddStudentAcademic(StudentAcademic studentAcademic)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            SessionManager.CreateStudent(HttpContext, studentAcademic, StudentStatus.LD_StudentAcademic);
            return Redirect("~/Add-Student-Level-Info");
        }

        [HttpGet("Add-Student-Level-Info")]
        public IActionResult AddStudentLevelInfo()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            var getData = SessionManager.GetStudent<List<StudentLevelInfo>>(HttpContext, StudentStatus.LD_StudentLevelInfo);
            return View(getData);
        }

        [HttpPost("AddStudentLevelInfo")]
        public void AddStudentLevelInfo(StudentLevelInfo studentLevelInfo)
        {
            if (!HttpContext.HasSession())
                return;
            List<StudentLevelInfo> getData = [];
            getData = SessionManager.GetStudent<List<StudentLevelInfo>>(HttpContext, StudentStatus.LD_StudentLevelInfo);

            getData.Add(studentLevelInfo);

            SessionManager.CreateStudent(HttpContext, getData, StudentStatus.LD_StudentLevelInfo);
        }

        [HttpPost("DeleteStudentLevelInfo")]
        public void DeleteStudentLevelInfo(Guid id)
        {
            if (!HttpContext.HasSession())
                return;
            List<StudentLevelInfo> getData = [];
            getData = SessionManager.GetStudent<List<StudentLevelInfo>>(HttpContext, StudentStatus.LD_StudentLevelInfo);

            getData.Remove(getData.First(x => x.UId == id));

            SessionManager.CreateStudent(HttpContext, getData, StudentStatus.LD_StudentLevelInfo);

        }

        [HttpPost("Add-Student-Level-Info")]
        public IActionResult AddStudentLevelInfo(bool done)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            return Redirect("~/Add-Student-Ability");

        }

        [HttpGet("Add-Student-Ability")]
        public IActionResult AddStudentAbility()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View(SessionManager.GetStudent<StudentAbility>(HttpContext, StudentStatus.LD_StudentAbility));
        }

        [HttpPost("Add-Student-Ability")]
        public async Task<IActionResult> AddStudentAbility(StudentAbility studentAbility)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            SessionManager.CreateStudent(HttpContext, studentAbility, StudentStatus.LD_StudentAbility);
            return Redirect("~/Add-Student-Visit-Center");
        }

        [HttpGet("Add-Student-Visit-Center")]
        public IActionResult AddStudentVisitCenter()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            var getData = SessionManager.GetStudent<List<StudentVisitCenter>>(HttpContext, StudentStatus.LD_StudentVisitCenter);
            return View(getData);
        }

        [HttpPost("AddStudentVisitCenter")]
        public void AddStudentVisitCenter(StudentVisitCenter studentVisitCenter)
        {
            if (!HttpContext.HasSession())
                return;
            List<StudentVisitCenter> getData = [];
            getData = SessionManager.GetStudent<List<StudentVisitCenter>>(HttpContext, StudentStatus.LD_StudentVisitCenter);

            getData.Add(studentVisitCenter);

            SessionManager.CreateStudent(HttpContext, getData, StudentStatus.LD_StudentVisitCenter);
        }

        [HttpPost("DeleteStudentVisitCenter")]
        public void DeleteStudentVisitCenter(Guid id)
        {
            if (!HttpContext.HasSession())
                return;
            List<StudentVisitCenter> getData = [];
            getData = SessionManager.GetStudent<List<StudentVisitCenter>>(HttpContext, StudentStatus.LD_StudentVisitCenter);

            getData.Remove(getData.First(x => x.UId == id));

            SessionManager.CreateStudent(HttpContext, getData, StudentStatus.LD_StudentVisitCenter);

        }

        [HttpPost("Add-Student-Visit-Center")]
        public IActionResult AddStudentVisitCenter(bool done)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            return Redirect("~/Add-Student-Mistake");

        }

        [HttpGet("Add-Student-Mistake")]
        public IActionResult AddStudentMistake()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            return View(SessionManager.GetStudent<StudentMistake>(HttpContext, StudentStatus.LD_StudentMistake));
        }

        [HttpPost("Add-Student-Mistake")]
        public IActionResult AddStudentMistake(StudentMistake studentMistake)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            SessionManager.CreateStudent(HttpContext, studentMistake, StudentStatus.LD_StudentMistake);
            return Redirect("~/Add-Student-Note");
        }


        [HttpGet("Save-LD-Student")]
        public async Task<IActionResult> SaveLDStudent()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            var student = SessionManager.GetStudent<Student>(HttpContext, StudentStatus.Student);
            var studentFamilyInfo = SessionManager.GetStudent<StudentFamilyInfo>(HttpContext, StudentStatus.StudentFamilyInfo);
            var studentSiblings = SessionManager.GetStudent<List<StudentSibling>>(HttpContext, StudentStatus.StudentSibling);
            var studentMotherMedical = SessionManager.GetStudent<StudentMotherMedical>(HttpContext, StudentStatus.StudentMotherMedical);
            var studentMedical = SessionManager.GetStudent<StudentMedical>(HttpContext, StudentStatus.StudentMedical);
            var studentMedicalTest = SessionManager.GetStudent<StudentMedicalTest>(HttpContext, StudentStatus.StudentMedicalTest);
            var studentPsychologyDevelopment = SessionManager.GetStudent<StudentPsychologyDevelopment>(HttpContext, StudentStatus.StudentPsychologyDevelopment);
            var studentFamilyActivity = SessionManager.GetStudent<StudentFamilyActivity>(HttpContext, StudentStatus.StudentFamilyActivity);
            var studentSocialDevelopment = SessionManager.GetStudent<StudentSocialDevelopment>(HttpContext, StudentStatus.StudentSocialDevelopment);
            var studentNote = SessionManager.GetStudent<StudentNote>(HttpContext, StudentStatus.StudentNote);

            var studentInterests = SessionManager.GetStudent<List<StudentInterests>>(HttpContext, StudentStatus.LD_StudentInterests);
            var studentAcademic = SessionManager.GetStudent<StudentAcademic>(HttpContext, StudentStatus.LD_StudentAcademic);
            var studentLevelInfo = SessionManager.GetStudent<List<StudentLevelInfo>>(HttpContext, StudentStatus.LD_StudentLevelInfo);
            var studentAbility = SessionManager.GetStudent<StudentAbility>(HttpContext, StudentStatus.LD_StudentAbility);
            var studentVisitCenter = SessionManager.GetStudent<List<StudentVisitCenter>>(HttpContext, StudentStatus.LD_StudentVisitCenter);
            //var studentMistake = SessionManager.GetStudent<StudentMistake>(HttpContext, StudentStatus.LD_StudentMistake);



            await studentService.AddLDStudent(student, studentFamilyInfo, studentSiblings, studentMotherMedical, studentMedical,
                studentMedicalTest, studentInterests, studentPsychologyDevelopment, studentSocialDevelopment, studentLevelInfo,
                studentFamilyActivity, studentAcademic, studentAbility, studentNote , studentVisitCenter);

            var getAccount = await accountService.GetAccount(HttpContext.GetMyId());
            HttpContext.Session.Clear();
            HttpContext.SetSession(getAccount);

            return View();
        }

    }
}