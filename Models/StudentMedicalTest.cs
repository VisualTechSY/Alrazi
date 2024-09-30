using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentMedicalTest
    {
        [ForeignKey("Student")]
        public int Id { get; set; }
        public Student Student { get; set; }
        [DisplayName("نوع تخطيط السمع")]
        public string AudiogramType { get; set; }
        [DisplayName("نتيجة تخطيط السمع")]
        public int AudiogramTypeResult { get; set; }
        [DisplayName("نوع فحص البصر")]
        public string EyeExamination { get; set; }
        [DisplayName("نتيجة فحص البصر")]
        public int EyeExaminationResult { get; set; }
        [DisplayName("نوع فحص الدماغ")]
        public string BrainScan { get; set; }
        [DisplayName("نتيجة فحص الدماغ")]
        public int BrainScanResult { get; set; }
        [DisplayName("التحاليل المخبرية")]
        public string LaboratoryTests { get; set; }
        [DisplayName("الأدوية السابقة")]
        public string PreviousMedications { get; set; }
        [DisplayName("الأدوية الحالية")]
        public string CurrentMedications { get; set; }

        //LD
        public string? DoctorDiagnosis { get; set; }
        public string? DiagnosisResult { get; set; }
        public string? DoctorAddress { get; set; }
        public string? DoctorNumber { get; set; }
    }
}
