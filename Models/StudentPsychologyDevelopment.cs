using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentPsychologyDevelopment
    {
        [ForeignKey("Student")]
        public int Id { get; set; }
        public Student Student { get; set; }
        [DisplayName("هل يضبط عملية الإخراج")]
        public bool OutputOperations { get; set; }
        [DisplayName("هل هنالك مشاكل في النوم")]
        public bool SleepProblems { get; set; }
        [DisplayName("هل لدى الطفل نشاط زائد")]
        public bool HyperActivity { get; set; }
        [DisplayName("هل يعاني من نوبات اختلاجية")]
        public bool Seizures { get; set; }
        [DisplayName("هل هنالك مشاكل أخرى")]
        public string OtherProblems { get; set; }
        public List<StudentPsychologyDevelopmentBehavioralProblem> StudentPsychologyDevelopmentBehavioralProblems { get; set; }

        //Early
        [DisplayName("هل هنالك مشاكل نطقية أو لغوية")]
        public bool LanguageProblems { get; set; }

        //LD
        [DisplayName("هل هنالك مشاكل في الأكل ومانوعها")]
        public string? EatProblems { get; set; }
        [DisplayName("هل هنالك يعاني من الحساسية ومانوعها")]
        public string? Allergy { get; set; }
    }
}
