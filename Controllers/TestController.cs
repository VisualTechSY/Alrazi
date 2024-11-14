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

        //عرض الإختبارات المتاحة للطالب
        public async Task<IActionResult> ShowTest(int studentId)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");
            Student student = await studentService.GetStudent(studentId);
            return View(student);
        }
        //إضافة اختبار للطالب ويتم من خلالها التوجيه لإضافة الاختبار
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
        //جلب جميع اختبارات الطالب لاختبار محدد
        public IActionResult GetTest(int studentId, TestType testType)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");

            return testType switch
            {
                TestType.Portage => RedirectToAction("GetTestPortage", new { studentId = studentId }),
                TestType.StanfordBinet => RedirectToAction("GetTestStanfordBinet", new { studentId = studentId }),
                _ => RedirectToAction("Index", "Home"),
            };
        }




        #region Portage

        public async Task<IActionResult> AddTestPortage(int studentId)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");

            Student student = await studentService.GetStudent(studentId);

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddTestPortage(TestPortage testPortage)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");
            int testId = await testService.AddTestPortage(testPortage);
            return RedirectToAction("GetTestPortgeReport", new { testId = testId });
        }
        //جلب تقرير الاختبار الواحد
        public async Task<IActionResult> GetTestPortgeReport(int testId)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");
            TestPortage getTest = await testService.GetTestPortageById(testId);
            return View(getTest);
        }

        public async Task<IActionResult> GetTestPortage(int studentId)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");

            List<TestPortageDetails> getTest = await testService.GetStudentTestPortage(studentId);
            return View(getTest);
        }

        #endregion

        #region StanfordBinet
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
            int testId = await testService.AddTestStanfordBinet(testStanfordBinet);
            return RedirectToAction("GetTestStanfordBinetReport", new { testId = testId });
        }
        //جلب تقرير الاختبار الواحد
        public async Task<IActionResult> GetTestStanfordBinetReport(int testId)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");
            TestStanfordBinet getTest = await testService.GetTestStanfordBinetById(testId);
            return View(getTest);
        }

        public async Task<IActionResult> GetTestStanfordBinet(int studentId)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");

            List<TestStanfordBinetDetails> getTest = await testService.GetStudentTestStanfordBinet(studentId);
            return View(getTest);
        }

        #endregion

    }
}
