using Alrazi.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentVisitCenter
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public string CenterName { get; set; }
        public string Diagnosis { get; set; }
        public string Duration { get; set; }
        public string Program { get; set; }
        public string Address { get; set; }
    }
}