using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentEducationalَualification
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public string CenterName { get; set; }
        public string Diagnosis { get; set; }
        public string Specialist { get; set; }
        public string Rehabilitation { get; set; }
        public string RehabilitationAxes { get; set; }
        public string Duration { get; set; }
    }
}
