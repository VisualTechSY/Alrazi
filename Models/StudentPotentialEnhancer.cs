using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentPotentialEnhancer
    {
        [ForeignKey("Student")]
        public int Id { get; set; }
        public Student Student { get; set; }
        public bool Food { get; set; }
        public bool Activity { get; set; }
        public bool Materialism { get; set; }
        public bool Symbolism { get; set; }
        public bool Social { get; set; }
    }
}
