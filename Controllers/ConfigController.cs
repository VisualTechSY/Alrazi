using Alrazi.HttpParameters;
using Alrazi.Services;
using Alrazi.Tools;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Alrazi.Controllers
{
    public class ConfigController : Controller
    {
        private readonly ConfigService configService;

        public ConfigController(ConfigService configService)
        {
            this.configService = configService;
        }

        [HttpGet("Get-Access-Channels")]
        public async Task<IActionResult> GetAccessChannels()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View(await configService.GetAccessChannels());
        }

        [HttpGet("Add-Access-Channel")]
        public IActionResult AddAccessChannel()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View();
        }

        [HttpPost("Add-Access-Channel")]
        public async Task<IActionResult> AddAccessChannel(string name)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            var data = await configService.AddAccessChannel(name);
            ViewBag.Done = data.Item1;
            ViewBag.Message = data.Item2;
            return View();
        }

        [HttpGet("Edit-Access-Channel/{id}")]
        public async Task<IActionResult> EditAccessChannel(int id)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View(await configService.GetAccessChannelById(id));
        }

        [HttpPost("Edit-Access-Channel")]
        public async Task<IActionResult> EditAccessChannel(int id, string name)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            var data = await configService.EditAccessChannel(id, name);
            ViewBag.Done = data.Item1;
            ViewBag.Message = data.Item2;
            return View(await configService.GetAccessChannelById(id));
        }

        [HttpGet("ChangeAccessChannelState/{id}")]
        public async Task<IActionResult> ChangeAccessChannelState(int id)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            await configService.ChangeAccessChannelState(id);
            return Redirect("~/Edit-Access-Channel/" + id);
        }

    }
}