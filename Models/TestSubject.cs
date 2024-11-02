using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class TestSubject
    {
        public int Id { get; set; }
        [ForeignKey("TestSubject")]
        public int TestId { get; set; }
        public Test Test { get; set; }


        public string Title { get; set; }
        public double MaxValue { get; set; }

    }
}
