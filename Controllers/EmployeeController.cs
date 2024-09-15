using Alrazi.HttpParameters;
using Alrazi.Services;
using Alrazi.Tools;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Alrazi.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AccountService accountService;

        public EmployeeController(AccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpGet("Add-Employee")]
        public IActionResult AddEmployee()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View();
        }

        [HttpPost("Add-Employee")]
        public async Task<IActionResult> AddEmployee(NewEmployee newEmployee)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            var data = await accountService.AddEmployee(newEmployee);
            ViewBag.Done = data.Item1;
            ViewBag.Message = data.Item2;
            return View();
        }

        [HttpGet("AnyUsername")]
        public async Task<bool> AnyUsername(string username)
        {
            if (!HttpContext.HasSession())
                throw new Exception();
            return await accountService.AnyUserName(username);
        }

        [HttpGet("Get-Employees")]
        public async Task<IActionResult> GetEmployees()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View(await accountService.GetEmployees());
        }

        [HttpGet("Edit-Employee/{id}")]
        public async Task<IActionResult> EditEmployee(int id)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View(await accountService.GetEmployeeById(id));
        }

        [HttpPost("Edit-Employee")]
        public async Task<IActionResult> EditEmployee(EditEmployee editEmployee)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            await accountService.EditEmployee(editEmployee);
            return View(await accountService.GetEmployeeById(editEmployee.Id));
        }

        [HttpGet("ResetPassword/{id}")]
        public async Task<IActionResult> ResetPassword(int id)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            await accountService.ResetPassword(id);
            return Redirect("~/Edit-Employee/" + id);
        }

    }
}