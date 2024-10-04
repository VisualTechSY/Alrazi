using Alrazi.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentVisitCenter
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        [DisplayName("اسم المركز")]
        public string CenterName { get; set; }
        [DisplayName("التشخيص")]
        public string Diagnosis { get; set; }
        [DisplayName("المدة")]
        public string Duration { get; set; }
        [DisplayName("البرنامج الذي تم العمل عليه")]
        public string Program { get; set; }
        [DisplayName("العنوان")]
        public string Address { get; set; }

        [NotMapped]
        public Guid UId { get; set; } = Guid.NewGuid();
    }
}