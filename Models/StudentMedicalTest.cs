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
        [DisplayName("الأدوية السابقة")]
        public string PreviousMedications { get; set; }
        [DisplayName("الأدوية الحالية")]
        public string CurrentMedications { get; set; }

        //Early
        [DisplayName("التحاليل المخبرية")]
        public string? LaboratoryTests { get; set; }

        //LD
        [DisplayName("تم التشخيص من قبل الطبيب")]
        public string? DoctorDiagnosis { get; set; }
        [DisplayName("نتائج التشخيص")]
        public string? DiagnosisResult { get; set; }
        [DisplayName("عنوانه")]
        public string? DoctorAddress { get; set; }
        [DisplayName("رقم هاتفه")]
        public string? DoctorNumber { get; set; }
    }
}
