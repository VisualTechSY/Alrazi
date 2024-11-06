using Alrazi.HttpParameters;
using Alrazi.Models;
using Alrazi.Services;
using Alrazi.Tools;
using Alrazi.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Alrazi.Controllers
{
    public class TestController : Controller
    {
        private readonly TestService testService;

        public TestController(TestService testService)
        {
            this.testService = testService;
        }


        [HttpGet("Add-Test-Student/{studentId}")]
        public async Task<IActionResult> AddTestStudent(int studentId, int testId)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            List<Test> avalableTest = await testService.GetAvalableTestForStudent(studentId);

            ViewBag.stdId = studentId;
            ViewBag.selectedTestId = testId;
            return View(avalableTest);
        }

        [HttpPost("Add-Test-Student")]
        public async Task<IActionResult> AddTestStudent(AddTestStudentVM testStudentVM)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            await testService.AddTestStudent(testStudentVM);

            ViewBag.stdId = testStudentVM.StudentId;
            ViewBag.selectedTestId = 0;
            return Redirect("~/Add-Test-Student/" + testStudentVM.StudentId);
        }


        [HttpGet("Get-Test-Student-Report/{studentId}")]
        public async Task<IActionResult> GetTestStudentReport(int studentId)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            List<StudentTestReportVM> studentTestReportVMs = await testService.GetTestStudentReport(studentId);
            return View(studentTestReportVMs);
        }

    }
}
