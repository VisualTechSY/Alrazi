using Alrazi.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentAbility
    {
        [ForeignKey("Student")]
        public int Id { get; set; }
        public Student Student { get; set; }
        public Focus Focus { get; set; }
        public bool IsQualified { get; set; }
        public RehabilitationSystem RehabilitationSystem { get; set; }
        public bool ContinuousTraining { get; set; }
        public string ReasonContinuousTraining { get; set; }
        public bool WeaknessRead { get; set; }
        public bool WeaknessWrite { get; set; }
        public bool WeaknessCalc { get; set; }
        public bool WeaknessSciences { get; set; }
    }
}
