using Alrazi.Services;
using Alrazi.Tools;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Alrazi.Controllers
{
    public class StudentController : Controller
    {
        private readonly AccountService accountService;

        public StudentController(AccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpGet("Add-Student")]
        public IActionResult AddStudent()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View();
        }

    }
}
