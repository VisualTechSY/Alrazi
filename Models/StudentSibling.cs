using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentSibling
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int Order { get; set; }
        public string FullName { get; set; }
        public bool IsMale { get; set; }
        public DateTime BirthDate { get; set; }
        public string StudyLevel { get; set; }

        [NotMapped]
        public Guid UId { get; set; } = Guid.NewGuid();
    }
}
