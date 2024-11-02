using Alrazi.HttpParameters;
using Alrazi.Models;
using Alrazi.Services;
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
            List<Test> x = await testService.GetAvalableTestForStudent(studentId);

            ViewBag.stdId = studentId;
            ViewBag.selectedTestId = testId;
            return View(x);
        }

        [HttpPost("Add-Test-Student")]
        public async Task<IActionResult> AddTestStudent(AddTestStudentVM testStudentVM)
        {
            await testService.AddTestStudent(testStudentVM);

            List<Test> x = await testService.GetAvalableTestForStudent(testStudentVM.StudentId);
            ViewBag.stdId = testStudentVM.StudentId;
            ViewBag.selectedTestId = 0;
            return Redirect("~/Add-Test-Student/" + testStudentVM.StudentId);
        }

        /*
        [HttpGet("Add-Test-Student/{id}")]
        public async Task<IActionResult> AddTestStudent(List<TestStudentVM> testStudent)
        {
            //if (!HttpContext.HasSession())
            //    return RedirectToAction("Index");
            await testService.AddTestStudent(testStudent);
            return View();
        }*/


    }
}
