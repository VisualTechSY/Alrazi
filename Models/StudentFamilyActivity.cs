using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentFamilyActivity
    {
        [ForeignKey("Student")]
        public int Id { get; set; }
        public Student Student { get; set; }
        public string RelationshipParents { get; set; }
        public string RelationshipSiblings { get; set; }
        public string FamilyVisits { get; set; }
        public string WatchingTV { get; set; }
        public string InteractCelebrations { get; set; }
        public string HandlingMoney { get; set; }
    }
}
