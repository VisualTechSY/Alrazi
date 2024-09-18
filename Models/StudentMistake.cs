using Alrazi.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentMistake
    {
        [ForeignKey("Student")]
        public int Id { get; set; }
        public Student Student { get; set; }
        public string CompareColleagues { get; set; }
        public string BehavioralDescription { get; set; }
        public string SchoolDealing { get; set; }
        public string UnderstandingWellBehaved { get; set; }
        public string AssaultsOthers { get; set; }
        public string SelfReliant { get; set; }
        public string ClearExpression { get; set; }
    }
}
