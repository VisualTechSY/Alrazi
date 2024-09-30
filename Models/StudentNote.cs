using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentNote
    {
        [ForeignKey("Student")]
        public int Id { get; set; }
        public Student Student { get; set; }
        [DisplayName("متى اكتشف الوالدان أول مرة أن حالة ابنهم غير طبيعية وكيف تم ذلك")]
        public string FirstDiscoveryParents { get; set; }
        [DisplayName("أية ملاحظات أخرى")]
        public string OtherNote { get; set; }

        //Early
        [DisplayName("وصف مشكلة الطالب كما يراها ولي األمر:")]
        public string? DescribeProblemAsSeenParents { get; set; }

        //LD
        public string? SpeakingWay { get; set; }
        public string? FamilyProblemsWithChild { get; set; }
        public string? SkillsRequiredChild { get; set; }
    }
}
