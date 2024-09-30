using Alrazi.Services;
using Alrazi.Tools;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Alrazi.Controllers
{
    public class HomeController : Controller
    {
        private readonly AccountService accountService;

        public HomeController(AccountService accountService)
        {
            this.accountService = accountService;
        }

        public IActionResult Index()
        {
            if (HttpContext.HasSession())
                return Redirect("~/Panel");

            return Redirect("~/Login");
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            if (HttpContext.HasSession())
                return RedirectToAction("Index");
            return View();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(string username , string password)
        {
            if (HttpContext.HasSession())
            {
                return RedirectToAction("Index");
            }
            var data = await accountService.Login(username, password);
            if (!string.IsNullOrWhiteSpace(data.Item2))
            {
                ViewBag.ErrorMessage = data.Item2;
                return View();
            }
            HttpContext.SetSession(data.Item1);
            return RedirectToAction("Index");
        }

        [HttpGet("Panel")]
        public IActionResult Panel()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View();
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("~/Login");
        }

    }
}
