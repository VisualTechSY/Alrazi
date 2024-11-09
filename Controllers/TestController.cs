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

        [HttpGet("Manage-Test")]
        public async Task<IActionResult> ManageTests()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            List<Test> tests = await testService.GetTests();
            return View(tests);
        }

        [HttpPost("Manage-Test")]
        public async Task<IActionResult> ManageTests(Test test)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            await testService.AddTest(test);

            List<Test> tests = await testService.GetTests();
            return View(tests);
        }

        [HttpGet("Manage-SubjectTest/{testId}")]
        public async Task<IActionResult> ManageTestSubjects(int testId)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            ViewBag.testid = testId;
            List<TestSubject> testSubjects = await testService.GetTestSubjects(testId);
            return View(testSubjects);
        }

        [HttpPost("Manage-SubjectTest/{testId}")]
        public async Task<IActionResult> ManageTestSubjects(TestSubject testSubject)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            await testService.AddTestSubject(testSubject);

            ViewBag.testid = testSubject.TestId;
            List<TestSubject> getTestSubjects = await testService.GetTestSubjects(testSubject.TestId);
            return View(getTestSubjects);
        }


        [HttpGet("Manage-TestResault/{testId}")]
        public async Task<IActionResult> ManageTestResault(int testId)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            ViewBag.testid = testId;

            List<TestResult> testResults = await testService.GetTestResults(testId);
            return View(testResults);
        }

        [HttpPost("Manage-TestResault/{testId}")]
        public async Task<IActionResult> ManageTestResault(int testId, TestResult testResult)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            await testService.AddTestResults(testResult);
            ViewBag.testid = testId;

            List<TestResult> testResults = await testService.GetTestResults(testId);
            return View(testResults);
        }
        [HttpGet("Manage-TestSubjectResault/{testSubjectId}")]
        public async Task<IActionResult> TestSubjectResault(int testSubjectId)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            List<TestSubjectResult> testSubjectResult = await testService.GetTestSubjectResults(testSubjectId);
            return View(testSubjectResult);
        }

        [HttpPost("Manage-TestSubjectResault/{testSubjectId}")]
        public async Task<IActionResult> ManageTestSubjectResault(int testSubjectId, TestSubjectResult testSubjectResult)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");

            await testService.AddTestSubjectResults(testSubjectResult);

            List<TestSubjectResult> GetTestSubjectResult = await testService.GetTestSubjectResults(testSubjectId);
            return View(GetTestSubjectResult);
        }
    }
}
