using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentEducationalualification
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        [DisplayName("اسم المركز")]
        public string CenterName { get; set; }
        [DisplayName("التشخيص")]
        public string Diagnosis { get; set; }
        [DisplayName("الأخصائي")]
        public string Specialist { get; set; }
        [DisplayName("التأهيل")]
        public string Rehabilitation { get; set; }
        [DisplayName("محاور التأهيل ")]
        public string RehabilitationAxes { get; set; }
        [DisplayName("المدة الزمنية")]
        public string Duration { get; set; }

        [NotMapped]
        public Guid UId { get; set; } = Guid.NewGuid();
    }
}
