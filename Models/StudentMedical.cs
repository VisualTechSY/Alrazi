using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentMedical
    {
        [ForeignKey("Student")]
        public int Id { get; set; }
        public Student Student { get; set; }
        public bool HeadInjury { get; set; }
        public bool SevereInfections { get; set; }
        public bool VaccineRelatedProblems { get; set; }
        public string Tests { get; set; }
    }
}
