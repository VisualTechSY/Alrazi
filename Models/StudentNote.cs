using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentNote
    {
        [ForeignKey("Student")]
        public int Id { get; set; }
        public Student Student { get; set; }
        public string FirstDiscoveryParents { get; set; }
        public string OtherNote { get; set; }

        //Early
        public string? DescribeProblemAsSeenParents { get; set; }

        //LD
        public string? SpeakingWay { get; set; }
        public string? FamilyProblemsWithChild { get; set; }
        public string? SkillsRequiredChild { get; set; }
    }
}
