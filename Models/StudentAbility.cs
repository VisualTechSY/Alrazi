using Alrazi.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentAbility
    {
        [ForeignKey("Student")]
        public int Id { get; set; }
        public Student Student { get; set; }
        [DisplayName("قدرته على الانتباه والتركيز")]
        public Focus Focus { get; set; }
        [DisplayName("نظام التأهيل الذي خضع له")]
        public RehabilitationSystem RehabilitationSystem { get; set; }
        [DisplayName("التأهيل الحالي")]
        public bool ContinuousTraining { get; set; }
        [DisplayName("سبب التأهيل الحالي")]
        public string ReasonContinuousTraining { get; set; }
        [DisplayName("ضعيف في القراءة")]
        public bool WeaknessRead { get; set; }
        [DisplayName("ضعيف في الكتابة")]
        public bool WeaknessWrite { get; set; }
        [DisplayName("ضعيف في الحساب")]
        public bool WeaknessCalc { get; set; }
        [DisplayName("ضعيف في العلوم")]
        public bool WeaknessSciences { get; set; }
    }
}
