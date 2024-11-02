using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class TestResult
    {
        public int Id { get; set; }
        [ForeignKey("Test")]
        public int TestId { get; set; }
        public Test Test { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public string Degree { get; set; }
    }
}
