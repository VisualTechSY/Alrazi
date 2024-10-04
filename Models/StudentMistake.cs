using Alrazi.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentMistake
    {
        [ForeignKey("Student")]
        public int Id { get; set; }
        public Student Student { get; set; }
        [DisplayName("عادية مقارنته بزملائه")]
        public string CompareColleagues { get; set; }
        [DisplayName("كثيرة مقارنة بزملائه وتستدعي تشخيص أعمق وأدق")]
        public string BehavioralDescription { get; set; }
        [DisplayName("كثيرة مقارنة بزملائه وتستدعي تشخيص أعمق وأدق")]
        public string SchoolDealing { get; set; }
        public string UnderstandingWellBehaved { get; set; }
        public string AssaultsOthers { get; set; }
        public string SelfReliant { get; set; }
        public string ClearExpression { get; set; }
    }
}
