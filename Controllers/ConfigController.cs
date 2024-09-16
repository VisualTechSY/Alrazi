using Alrazi.HttpParameters;
using Alrazi.Models;
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

        [HttpGet("Get-Diagnoses")]
        public async Task<IActionResult> GetDiagnoses()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View(await configService.GetDiagnoses()); 
        }

        [HttpGet("Add-Diagnosis")]
        public IActionResult AddDiagnosis()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View();
        }

        [HttpPost("Add-Diagnosis")]
        public async Task<IActionResult> AddDiagnosis(string name)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            var data = await configService.AddDiagnosis(name);
            ViewBag.Done = data.Item1;
            ViewBag.Message = data.Item2;
            return View();
        }

        [HttpGet("Edit-Diagnosis/{id}")]
        public async Task<IActionResult> EditDiagnosis(int id)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View(await configService.GetDiagnosisById(id));
        }

        [HttpPost("Edit-Diagnosis")]
        public async Task<IActionResult> EditDiagnosis(int id, string name)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            var data = await configService.EditDiagnosis(id, name);
            ViewBag.Done = data.Item1;
            ViewBag.Message = data.Item2;
            return View(await configService.GetDiagnosisById(id));
        }

        [HttpGet("ChangeDiagnosisState/{id}")]
        public async Task<IActionResult> ChangeDiagnosisState(int id)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            await configService.ChangeDiagnosisState(id);
            return Redirect("~/Edit-Diagnosis/" + id);
        }

        [HttpGet("Get-Nationalities")]
        public async Task<IActionResult> GetNationalities()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View(await configService.GetNationalities());
        }

        [HttpGet("Add-Nationality")]
        public IActionResult AddNationality()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View();
        }

        [HttpPost("Add-Nationality")]
        public async Task<IActionResult> AddNationality(string name)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            var data = await configService.AddNationality(name);
            ViewBag.Done = data.Item1;
            ViewBag.Message = data.Item2;
            return View();
        }

        [HttpGet("Edit-Nationality/{id}")]
        public async Task<IActionResult> EditNationality(int id)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View(await configService.GetNationalityById(id));
        }

        [HttpPost("Edit-Nationality")]
        public async Task<IActionResult> EditNationality(int id, string name)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            var data = await configService.EditNationality(id, name);
            ViewBag.Done = data.Item1;
            ViewBag.Message = data.Item2;
            return View(await configService.GetNationalityById(id));
        }

        [HttpGet("ChangeNationalityState/{id}")]
        public async Task<IActionResult> ChangeNationalityState(int id)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            await configService.ChangeNationalityState(id);
            return Redirect("~/Edit-Nationality/" + id);
        }

        [HttpGet("Manage-Configs")]
        public async Task<IActionResult> ManageConfigs()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View(await configService.GetConfigs());
        }

        [HttpPost("Manage-Configs")]
        public async Task<IActionResult> ManageConfigs(List<Config> configs)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            await configService.UpdateConfigs(configs.ToArray());
            return View(await configService.GetConfigs());
        }
    }
}