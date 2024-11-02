using Alrazi.Enums;

namespace Alrazi.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public StudentStatus StudentType { get; set; }
        public List<TestSubject> TestSubjects { get; set; }
    }
}
