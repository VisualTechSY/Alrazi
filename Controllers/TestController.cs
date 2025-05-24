using Alrazi.Enums.Test;
using Alrazi.Models;
using Alrazi.Models.Test;
using Alrazi.Services;
using Alrazi.Tools;
using Alrazi.ViewModel;
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
            Student student = await testService.GetLastTestPortage(studentId);
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
                TestType.PortageSkill => RedirectToAction("AddTestPortageSkill", new { studentId = studentId }),
                TestType.Raven => RedirectToAction("AddTestRaven", new { studentId = studentId }),
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
                TestType.PortageSkill => RedirectToAction("GetTestPortageSkill", new { studentId = studentId }),
                TestType.Raven => RedirectToAction("GetTestRaven", new { studentId = studentId }),
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

        public async Task<IActionResult> EditTestPortage(int testid)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");

            TestPortage getTest = await testService.GetTestPortageById(testid);
            return View(getTest);
        }

        [HttpPost]
        public async Task<IActionResult> EditTestPortage(TestPortage testPortage)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");
            await testService.EditTestPortage(testPortage);
            return RedirectToAction("EditTestPortage", new { testId = testPortage.Id });
        }

        public async Task<IActionResult> DeleteTestPortage(int id, int stdId)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");

            string msg = await testService.DeleteTestPortage(id);

            if (!string.IsNullOrEmpty(msg))
            {
                TempData["ErrorMessage"] = msg;
                return Redirect("~/Test/EditTestPortage?testId=" + id);
            }
            return Redirect("~/Test/GetTestPortage?studentId=" + stdId);
        }



        public async Task<IActionResult> AddTestPortageSkill(int studentId)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");
            Student testPortages = await testService.GetLastTestPortage(studentId);
            ViewBag.selectedTestId = testPortages.TestPortages.Any() ? testPortages.TestPortages[0].Id : 0;
            return View(testPortages);
        }

        [HttpPost]
        public async Task<IActionResult> AddTestPortageSkill(TestPortage testPortage)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");

            int stdId = await testService.AddTestPortageSkill(testPortage);
            ViewBag.selectedTestId = testPortage.Id;
            return RedirectToAction("GetTestPortageSkill", new { studentId = stdId });
        }

        //طباعة تقرير الاختبار الواحد
        public async Task<IActionResult> GetTestPortgeReport(int testId)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");
            TestPortage getTest = await testService.GetTestPortageById(testId);
            return View(getTest);
        }
        [HttpPost]
        public async Task<IActionResult> GetTestPortgeReport(TestPortage testPortage)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");
            TestPortage getTest = await testService.UpdateSummaryTestPortage(testPortage);
            return View(getTest);
        }

        public async Task<IActionResult> GetTestPortage(int studentId)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");

            List<TestPortageDetails> getTest = await testService.GetStudentTestPortage(studentId);
            return View(getTest);
        }
        public async Task<IActionResult> GetTestPortageSkill(int studentId)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");

            List<TestPortage> getTest = await testService.GetStudentTestPortageSkill(studentId);
            return View(getTest);
        }
        public async Task<IActionResult> GetTestPortageIndividualPlan(int studentId)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");

            List<TestPortageIndividualPlanVM> testPortageIndividualPlanVMs = TestManager.GetTestPortageIndividualPlanVM();
            var getStudent = await studentService.GetStudent(studentId);
            ViewBag.FullName = getStudent.FullName;
            ViewBag.BirthDate = getStudent.BirthDate.ToShortDateString();
            return View(testPortageIndividualPlanVMs);
        }

        #endregion

        #region StanfordBinet
        public async Task<IActionResult> AddTestStanfordBinet(int studentId)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");

            Student student = await studentService.GetStudent(studentId);

            return View(student);
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
        [HttpPost]
        public async Task<IActionResult> GetTestStanfordBinetReport(TestStanfordBinet testStanfordBinet)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");
            TestStanfordBinet getTest = await testService.UpdateSummaryTesttStanfordBinet(testStanfordBinet);
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

        #region Raven
        public async Task<IActionResult> AddTestRaven(int studentId)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");

            Student student = await studentService.GetStudent(studentId);

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddTestRaven(TestRaven testRaven)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");
            int testId = await testService.AddTestRaven(testRaven);
            return RedirectToAction("GetTestRavenReport", new { testId = testId });
        }

        //جلب تقرير الاختبار الواحد
        public async Task<IActionResult> GetTestRavenReport(int testId)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");
            TestRaven getTest = await testService.GetTestRavenById(testId);
            return View(getTest);
        }

        public async Task<IActionResult> GetTestRaven(int studentId)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");

            List<TestRaven> getTest = await testService.GetStudentTestRaven(studentId);
            return View(getTest);
        }

        #endregion





        #region AchievementTests

        public async Task<IActionResult> GetAchievementTestsSchoolReadinessQS(int studentId)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");

            List<AchievementTestsSchoolReadinessQSVM> achievementTestsSchoolReadinessQSVMs = TestManager.GetAchievementTestsSchoolReadinessQS();
            var getStudent = await studentService.GetStudent(studentId);
            ViewBag.FullName = getStudent.FullName;
            ViewBag.BirthDate = getStudent.BirthDate.ToShortDateString();
            return View(achievementTestsSchoolReadinessQSVMs);
        }


        public async Task<IActionResult> GetAchievementTestArabic(int testId)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");
            List<string> testsArabic = TestManager.GetAchievementTestArabic(testId);
            return View(testsArabic);
        }

        #endregion


    }
}
