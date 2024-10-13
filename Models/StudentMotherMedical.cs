using Alrazi.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentMotherMedical
    {
        [ForeignKey("Student")]
        public int Id { get; set; }
        public Student Student { get; set; }
        [DisplayName("اختلاطات أثناء الحمل")]
        public string ComplicationsDuringPregnancy { get; set; }
        public DateTime MotherAgeAtBirth { get; set; }
        [DisplayName("هل تعرضت الأم للأشعة أثناء الحمل وفي أي شهر من الحمل")]
        public string MonthMotherExposedRadiation { get; set; }
        [DisplayName("هل تناولت عقاقير طبية أثناء الحمل")]
        public bool TookMedicationWhilePregnant { get; set; }
        [DisplayName("حالة الأم النفسية أثناء الحمل")]
        public string PsychologicalState { get; set; }
        [DisplayName("مدة الحمل")]
        public int PregnancyDuration { get; set; }
        [DisplayName("نوع الولادة")]
        public BirthType BirthType { get; set; }
        [DisplayName("مكان الولادة")]
        public string PlaceBirth { get; set; }
        [DisplayName("المشرف على الولادة")]
        public string BirthSupervisor { get; set; }
        [DisplayName("المدة التي قضاها في الحاضنة")]
        public string NurseryLong { get; set; }
        [DisplayName("سبب الحاضنة")]
        public string NurseryReason { get; set; }
        [DisplayName("النمو مكتمل")]
        public bool GrowthComplete { get; set; }
        [DisplayName("هل أزرق لونه")]
        public bool IsBlue { get; set; }
        [DisplayName("أصيب باليرقان")]
        public bool GotJaundice { get; set; }
        [DisplayName("العامل الريزوسي")]
        public string RhesusFactor { get; set; }
        [DisplayName("أي مشاكل أخرى")]
        public string OtherProblem { get; set; }
        public int GetMotherAtBirthYear => MotherAgeAtBirth == default ? 0 : DateTime.Now.Year - MotherAgeAtBirth.Year;
        [NotMapped]
        [DisplayName("عمر الأم عند الإنجاب")]
        public int MotherAtBirthYear { get; set; }
    }
}