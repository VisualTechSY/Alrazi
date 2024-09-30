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

        [HttpGet("Add-Student-Teacher")]
        public IActionResult AddStudentTeacher()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View();
        }

    }
}