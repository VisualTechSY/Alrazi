using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentAutonomy
    {
        [ForeignKey("Student")]
        public int Id { get; set; }
        public Student Student { get; set; }
        public string Food { get; set; }
        public string Drink { get; set; }
        public string Cleanliness { get; set; }
        public string Clothes { get; set; }
    }
}
