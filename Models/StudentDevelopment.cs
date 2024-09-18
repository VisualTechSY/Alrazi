using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentDevelopment
    {
        [ForeignKey("Student")]
        public int Id { get; set; }
        public Student Student { get; set; }
        public string Breastfeeding { get; set; }
        public string Teething { get; set; }
        public string ChewingFood { get; set; }
        public string Walking { get; set; }
        public string Signal { get; set; }
        public string Immunity { get; set; }
        public string FirstWords { get; set; } //split ,
    }
}
