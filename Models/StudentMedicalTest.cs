using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentMedicalTest
    {
        [ForeignKey("Student")]
        public int Id { get; set; }
        public Student Student { get; set; }
        public string AudiogramType { get; set; }
        public int AudiogramTypeResult { get; set; }
        public string EyeExamination { get; set; }
        public int EyeExaminationResult { get; set; }
        public string BrainScan { get; set; }
        public int BrainScanResult { get; set; }
        public string LaboratoryTests { get; set; }
        public string PreviousMedications { get; set; }
        public string CurrentMedications { get; set; }

        //LD
        public string? DoctorDiagnosis { get; set; }
        public string? DiagnosisResult { get; set; }
        public string? DoctorAddress { get; set; }
        public string? DoctorNumber { get; set; }
    }
}
