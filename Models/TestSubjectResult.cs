using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class TestSubjectResult
    {
        public int Id { get; set; }

        public int TestSubjectId { get; set; }
        public TestSubject TestSubject { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }

        public int AgeOfMounth { get; set; }//العمر النمائي
        public string Degree { get; set; }
    }
}
