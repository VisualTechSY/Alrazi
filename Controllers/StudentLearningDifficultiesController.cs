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

        public StudentLearningDifficultiesController(ConfigService configService , StudentService studentService)
        {
            this.configService = configService;
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
            return Redirect("~/Add-Student-Family-Info");
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

            return Redirect("~/Add-Student-Academic");

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

            return Redirect("~/Add-Student-Note");

        }

    }
}