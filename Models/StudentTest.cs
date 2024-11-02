using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentTest
    {
        public int Id { get; set; }

        public int TestSubjectId { get; set; }
        public TestSubject TestSubject { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int SerialNumber { get; set; }
        public int NumberCorrectAnswers { get; set; }
        public double Mark { get; set; }
        public DateTime TestDate { get; set; } = DateTime.Now;
    }
}
