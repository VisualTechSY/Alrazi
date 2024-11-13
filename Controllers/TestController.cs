using Alrazi.Enums.Test;
using Alrazi.Models;
using Alrazi.Models.Test;
using Alrazi.Services;
using Alrazi.Tools;
using Microsoft.AspNetCore.Mvc;

namespace Alrazi.Controllers
{
    public class TestController : Controller
    {
        private readonly TestService testService;
        private readonly StudentService studentService;

        public TestController(TestService testService, StudentService studentService)
        {
            this.testService = testService;
            this.studentService = studentService;
        }

        public async Task<IActionResult> ShowTest(int studentId)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");
            Student student = await studentService.GetStudent(studentId);
            return View(student);
        }
        //      public async Task<IActionResult> GetTest(int studentId, TestType testType)
        //      {
        //          if (!HttpContext.HasSession())
        //              return RedirectToAction("Index", "Home");

        //	return testType switch
        //	{
        //		TestType.Portage => RedirectToAction("GetTestPortage", new { studentId = studentId }),
        //		TestType.StanfordBinet => RedirectToAction("GetTestStanfordBinet", new { studentId = studentId }),
        //		_ => RedirectToAction("Index", "Home"),
        //	};

        //}
        public IActionResult AddTest(int studentId, TestType testType)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");
            return testType switch
            {
                TestType.Portage => RedirectToAction("AddTestPortage", new { studentId = studentId }),
                TestType.StanfordBinet => RedirectToAction("AddTestStanfordBinet", new { studentId = studentId }),
                _ => RedirectToAction("Index", "Home"),
            };
        }

        public IActionResult AddTestPortage(int studentId)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");
            ViewBag.stdId = studentId;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTestPortage(TestPortage testPortage)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");
            await testService.AddTestPortage(testPortage);
            return View();//todo تحويل لنافذة طباعة التقرير
        }

        public IActionResult AddTestStanfordBinet(int studentId)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");
            ViewBag.stdId = studentId;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTestStanfordBinet(TestStanfordBinet testStanfordBinet)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");
            await testService.AddTestStanfordBinet(testStanfordBinet);
            return View();//todo تحويل لنافذة طباعة التقرير
        }
    }
}
