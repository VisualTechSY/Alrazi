using Alrazi.Models;
using Alrazi.Services;
using Alrazi.Tools;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Alrazi.Controllers
{
    public class HomeController : Controller
    {
        private readonly AccountService accountService;
        private readonly WebsiteService websiteService;

        public HomeController(AccountService accountService , WebsiteService websiteService)
        {
            this.accountService = accountService;
            this.websiteService = websiteService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await websiteService.GetLastBlog(3));
        }

        [HttpPost]
        public async Task AddContact(string fullName , string message , string phoneNumber)
        {
            await websiteService.AddMessage(new Models.ContactMessage
            {
                FullName = fullName,
                Message = message,
                SendDate = DateTime.Now,
                PhoneNumber = phoneNumber,
            });
        }

        public async Task<List<Blog>> GetLastBlogs()
        {
            return await websiteService.GetLastBlog(3);
        }

        public async Task<IActionResult> Blogs()
        {
            return View(await websiteService.GetBlogs());
        }

        public async Task<IActionResult> Blog(int id)
        {
            ViewData["LastBlogs"] = await websiteService.GetLastBlog(3);
            return View(await websiteService.GetBlog(id));
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