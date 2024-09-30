using Alrazi.Enums;
using Alrazi.Models;
using Alrazi.Services;
using Alrazi.Tools;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

            ViewData["Nationalities"] = (await configService.GetNationalities()).Where(x=> x.IsActive).ToList();
            ViewData["AccessChannels"] = (await configService.GetAccessChannels()).Where(x=> x.IsActive).ToList();
            ViewData["Diagnoses"] = (await configService.GetDiagnoses()).Where(x=> x.IsActive).ToList();

            return View(SessionManager.GetStudent<Student>(HttpContext , StudentStatus.Early_Student));
        }

        [HttpPost("Add-Student")]
        public async Task<IActionResult> AddStudent(Student student)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            SessionManager.CreateStudent(HttpContext, student, StudentStatus.Early_Student);
            var configAge = (await configService.GetConfigs()).First(x => x.ConfigKey == ConfigKey.MinStudyDate).Value;
            if (student.GetAge() > Convert.ToInt16(configAge))
                return Redirect("~/Add-Student-Teacher");
            return Redirect("~/Add-Student-Family-Info");
        }

    }
}