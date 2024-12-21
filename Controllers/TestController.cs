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
                TestType.PortageSkill => RedirectToAction("AddTestPortageSkill", new { studentId = studentId }),
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

        public async Task<IActionResult> AddTestPortageSkill(int studentId, int testId)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");
            ViewBag.selectedTestId = testId;
            Student testPortages = await testService.GetTestPortageWithOutSkill(studentId);
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
        public async Task<IActionResult> GetTestPortageIndividualPlan()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index", "Home");

            List<string> plans = new()
            {
             "ينظر لشخص يحاول أن يشد انتباهه بالحديث إليه أو الحركة أمامه",
             "يبتسم، أو يصدر أصوات أو يكف عن البكاء استجابة لوجوده في محيط العائلة.",
             "يربت ويشد على ملامح وجه شخص كبير(الشعر، الأنف ، النظارات..الخ)",
             "يتواصل بصرياً لمدة من 2 - 3 دقائق عندما يكون برعاية شخص",
             "يلعب لعبة الاستغماية باليد(أوبي ، دي عيني ، بيكابو) مقلداً",
             "يصفق باليدين مقلداً الكبار",
             "يقول باي، باي بيده مقلدا الكبار",
             "يحضن، ويربت يقبل أشخاص مألوفين",
             "يتجاوب عند سماع اسمه الشخصي بالنظر أو مد الذراعين كي يحمل",
             "يمد اللعب أو الأشياء إلى الكبير ويطلق سراحها",
             "يشارك بأشياء أو طعام مع الآخرين عندما يطلب منه",
             "يحيي أطفال بعمره ومكانته والكبار المألوفين عندما يذكر",
             "يحضر أو يأخذ شيء من غرفة إلى أخرى عندما يعطى التعليمات",
             "يظهر محاولة لمساعدة والدته أو والده بمهامهما وذلك بعمل جزء من الشغل: حمل الغسيل ، نقل المكنسة ... إلخ",
             "يحيي الكبار المألوفين لديه بدون تذكير",
             "يقول شكراً من غير تذكير حوالي 50 % من الوقت",
             "يجيب على الهاتف، ينادي الكبير أو يتحدث إلى شخص مألوف",
             "يستجيب لطلب الكبار 75 % من الوقت",
             "يجيب على أسئلة الكبار الموجهة له حول ألعابه أو اهتماماته",
             "يأخذ الأذن لاستعمال أدوات تخص الآخرين 75 % من الوقت"
            };
            return View(plans);
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
