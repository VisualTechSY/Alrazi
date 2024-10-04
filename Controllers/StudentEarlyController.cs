using Alrazi.Enums;
using Alrazi.Models;
using Alrazi.Services;
using Alrazi.Tools;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Alrazi.Controllers
{
    public class StudentEarlyController : Controller
    {
        private readonly ConfigService configService;
        private readonly StudentService studentService;

        public StudentEarlyController(ConfigService configService , StudentService studentService)
        {
            this.configService = configService;
            this.studentService = studentService;
        }

        [HttpGet("Add-Student-Development")]
        public IActionResult AddStudentDevelopment()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View(SessionManager.GetStudent<StudentDevelopment>(HttpContext, StudentStatus.Early_StudentDevelopment));
        }

        [HttpPost("Add-Student-Development")]
        public IActionResult AddStudentDevelopment(StudentDevelopment studentDevelopment)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            SessionManager.CreateStudent(HttpContext, studentDevelopment, StudentStatus.Early_StudentDevelopment);
            return Redirect("~/Add-Student-Social-Development");
        }

       

        [HttpGet("Add-Student-Autonomy")]
        public IActionResult AddStudentAutonomy()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View(SessionManager.GetStudent<StudentAutonomy>(HttpContext, StudentStatus.Early_StudentAutonomy));
        }

        [HttpPost("Add-Student-Autonomy")]
        public IActionResult AddStudentAutonomy(StudentAutonomy studentAutonomy)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            SessionManager.CreateStudent(HttpContext, studentAutonomy, StudentStatus.Early_StudentAutonomy);
            return Redirect("~/Add-Student-Potential-Enhancer");
        }

        

        [HttpGet("Add-Student-Potential-Enhancer")]
        public IActionResult AddStudentPotentialEnhancer()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View(SessionManager.GetStudent<StudentPotentialEnhancer>(HttpContext, StudentStatus.Early_StudentPotentialEnhancer));
        }

        [HttpPost("Add-Student-Potential-Enhancer")]
        public IActionResult AddStudentPotentialEnhancer(StudentPotentialEnhancer studentPotentialEnhancer)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            SessionManager.CreateStudent(HttpContext, studentPotentialEnhancer, StudentStatus.Early_StudentPotentialEnhancer);
            return Redirect("~/Add-Student-Educationalualification");
        }

        [HttpGet("Add-Student-Educationalualification")]
        public IActionResult AddStudentEducationalualification()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return View(SessionManager.GetStudent<List<StudentEducationalualification>>(HttpContext, StudentStatus.Early_StudentEducationalualification));
        }

        [HttpPost("AddStudentEducationalualification")]
        public void AddStudentEducationalualification(StudentEducationalualification studentEducationalualification)
        {
            if (!HttpContext.HasSession())
                return;
            var getData = SessionManager.GetStudent<List<StudentEducationalualification>>(HttpContext, StudentStatus.Early_StudentEducationalualification);
            getData.Add(studentEducationalualification);
            SessionManager.CreateStudent(HttpContext, getData, StudentStatus.Early_StudentEducationalualification);
        }

        [HttpPost("DeleteStudentEducationalualification")]
        public void DeleteStudentEducationalualification(Guid id)
        {
            if (!HttpContext.HasSession())
                return;
            var getData = SessionManager.GetStudent<List<StudentEducationalualification>>(HttpContext, StudentStatus.Early_StudentEducationalualification);
            getData.Remove(getData.First(x => x.UId == id));
            SessionManager.CreateStudent(HttpContext, getData, StudentStatus.Early_StudentEducationalualification);
        }

        [HttpPost("Add-Student-Educationalualification")]
        public IActionResult AddStudentEducationalualification(bool done)
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            return Redirect("~/Add-Student-Note");
        }

        [HttpGet("Save-Student")]
        public async Task<IActionResult> SaveStudent()
        {
            if (!HttpContext.HasSession())
                return RedirectToAction("Index");
            var student = SessionManager.GetStudent<Student>(HttpContext, StudentStatus.Student);
            var studentFamilyInfo = SessionManager.GetStudent<StudentFamilyInfo>(HttpContext, StudentStatus.StudentFamilyInfo);
            var studentSiblings = SessionManager.GetStudent<List<StudentSibling>>(HttpContext, StudentStatus.StudentSibling);
            var studentMotherMedical = SessionManager.GetStudent<StudentMotherMedical>(HttpContext, StudentStatus.StudentMotherMedical);
            var studentMedical = SessionManager.GetStudent<StudentMedical>(HttpContext, StudentStatus.StudentMedical);
            var studentMedicalTest = SessionManager.GetStudent<StudentMedicalTest>(HttpContext, StudentStatus.StudentMedicalTest);
            var studentDevelopment = SessionManager.GetStudent<StudentDevelopment>(HttpContext, StudentStatus.Early_StudentDevelopment);
            var studentPsychologyDevelopment = SessionManager.GetStudent<StudentPsychologyDevelopment>(HttpContext, StudentStatus.StudentPsychologyDevelopment);
            var studentSocialDevelopment = SessionManager.GetStudent<StudentSocialDevelopment>(HttpContext, StudentStatus.StudentSocialDevelopment);
            var studentAutonomy = SessionManager.GetStudent<StudentAutonomy>(HttpContext, StudentStatus.Early_StudentAutonomy);
            var studentFamilyActivity = SessionManager.GetStudent<StudentFamilyActivity>(HttpContext, StudentStatus.StudentFamilyActivity);
            var studentPotentialEnhancer = SessionManager.GetStudent<StudentPotentialEnhancer>(HttpContext, StudentStatus.Early_StudentPotentialEnhancer);
            var studentEducationalualifications = SessionManager.GetStudent<List<StudentEducationalualification>>(HttpContext, StudentStatus.Early_StudentEducationalualification);
            var studentNote = SessionManager.GetStudent<StudentNote>(HttpContext, StudentStatus.StudentNote);
            await studentService.AddEarlyStudent(student, studentFamilyInfo, studentSiblings, studentMotherMedical, studentMedical,
                studentMedicalTest, studentDevelopment, studentPsychologyDevelopment, studentSocialDevelopment, studentAutonomy,
                studentFamilyActivity, studentPotentialEnhancer, studentEducationalualifications, studentNote);
            return View();
        }
    }
}