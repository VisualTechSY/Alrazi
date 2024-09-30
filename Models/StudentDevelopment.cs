using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentDevelopment
    {
        [ForeignKey("Student")]
        public int Id { get; set; }
        public Student Student { get; set; }
        [DisplayName("الرضاعة")]
        public string Breastfeeding { get; set; }
        [DisplayName("التسنين")]
        public string Teething { get; set; }
        [DisplayName("مضغ الطعام")]
        public string ChewingFood { get; set; }
        [DisplayName("المشي")]
        public string Walking { get; set; }
        [DisplayName("الإشارة")]
        public string Signal { get; set; }
        [DisplayName("المناعة")]
        public string Immunity { get; set; }
        [DisplayName("الكلمات الأولى")]
        public string FirstWords { get; set; } //split ,
    }
}
