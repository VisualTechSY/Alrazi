using Alrazi.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentInterests
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public Interests Interests { get; set; }
        public string Value { get; set; }

        [NotMapped]
        public Guid UId { get; set; } = Guid.NewGuid();
    }
}