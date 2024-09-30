using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentFamilyActivity
    {
        [ForeignKey("Student")]
        public int Id { get; set; }
        public Student Student { get; set; }
        [DisplayName("علاقته مع والديه")]
        public string RelationshipParents { get; set; }
        [DisplayName("علاقته مع أخوته")]
        public string RelationshipSiblings { get; set; }
        [DisplayName("زيارات مع العائلة")]
        public string FamilyVisits { get; set; }
        [DisplayName("مشاهدات التلفيزيون")]
        public string WatchingTV { get; set; }
        [DisplayName("تفاعله مع الموسيقى والاحتفالات")]
        public string InteractCelebrations { get; set; }
        [DisplayName("التعامل مع النقود")]
        public string HandlingMoney { get; set; }
    }
}
