using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentAcademic
    {
        [ForeignKey("Student")]
        public int Id { get; set; }
        public Student Student { get; set; }
        public bool LoveSchool { get; set; }
        public string TopStudyLevel { get; set; }
        public string ReasonFailure { get; set; }
        public string ReplayInformation { get; set; }
        public string MovingSchoolInformation { get; set; }
    }
}
