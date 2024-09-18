using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentMotherMedical
    {
        [ForeignKey("Student")]
        public int Id { get; set; }
        public Student Student { get; set; }
        public bool ComplicationsDuringPregnancy { get; set; }
        public string MonthMotherExposedRadiation { get; set; }
        public bool TookMedicationWhilePregnant { get; set; }
        public int PregnancyDuration { get; set; }
        public bool IsNatural { get; set; }
        public string PlaceBirth { get; set; }
        public string NurseryLong { get; set; }
        public string NurseryReason { get; set; }
        public bool GrowthComplete { get; set; }
        public bool GotJaundice { get; set; }
        public string RhesusFactor { get; set; }
        public string OtherProblem { get; set; }
    }
}
