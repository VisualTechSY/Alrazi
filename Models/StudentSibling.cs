using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentSibling
    {
        [ForeignKey("Student")]
        public int Id { get; set; }
        public Student Student { get; set; }
        public int Order { get; set; }
        public string FullName { get; set; }
        public bool IsMale { get; set; }
        public DateTime BirthDate { get; set; }
        public string StudyLevel { get; set; }
    }
}
