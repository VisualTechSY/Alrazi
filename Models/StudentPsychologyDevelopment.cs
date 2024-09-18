using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentPsychologyDevelopment
    {
        [ForeignKey("Student")]
        public int Id { get; set; }
        public Student Student { get; set; }
        public string OutputOperations { get; set; }
        public string SleepProblems { get; set; }
        public string HyperActivity { get; set; }
        public string Seizures { get; set; }
        public string LanguageProblems { get; set; }
        public string OtherProblems { get; set; }

        //LD
        public string? EatProblems { get; set; }
        public string? Allergy { get; set; }
    }
}
