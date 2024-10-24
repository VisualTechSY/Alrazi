using Alrazi.Enums;

namespace Alrazi.DTO
{
    public class StudentInfo
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string MotherName { get; set; }
        public string PhoneNumber { get; set; }
        public StudentStatus StudentStatus { get; set; }
    }
}