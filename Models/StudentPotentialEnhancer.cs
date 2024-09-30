using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentPotentialEnhancer
    {
        [ForeignKey("Student")]
        public int Id { get; set; }
        public Student Student { get; set; }
        [DisplayName("غذائية")]
        public bool Food { get; set; }
        [DisplayName("نشاطية")]
        public bool Activity { get; set; }
        [DisplayName("مادية")]
        public bool Materialism { get; set; }
        [DisplayName("رمزية")]
        public bool Symbolism { get; set; }
        [DisplayName("اجتماعية")]
        public bool Social { get; set; }
    }
}
