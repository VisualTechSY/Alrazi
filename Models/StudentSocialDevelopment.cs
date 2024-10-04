using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentSocialDevelopment
    {
        [ForeignKey("Student")]
        public int Id { get; set; }
        public Student Student { get; set; }
        [DisplayName("التواصل البصري")]
        public string VisualCommunication { get; set; }
        [DisplayName("التواصل القصدي")]
        public string IntentionalCommunication { get; set; }
        [DisplayName("التعابير الوجهية")]
        public string FacialExpressions { get; set; }
        [DisplayName("اللعب")]
        public string Play { get; set; }
        [DisplayName("تفاعله مع الآخرين")]
        public string Interaction { get; set; }

        //Early
        [DisplayName("علاقته مع أطفال آخرين بمستوى عمره")]
        public string? ChildRelationships { get; set; }

        //LD
        [DisplayName("المساعدة في المنزل")]
        public string? HouseHelp { get; set; }

    }
}
