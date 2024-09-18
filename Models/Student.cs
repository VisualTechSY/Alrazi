using Alrazi.Enums;

namespace Alrazi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public StudentStatus StudentStatus { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StateNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime AgeTimeDate { get; set; }
        public DateTime StudyStateDate { get; set; }
        public bool IsMale { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int NationalityId { get; set; }
        public Nationality Nationality { get; set; }
        public int AccessChannelId { get; set; }
        public AccessChannel AccessChannel { get; set; }
        public DateTime AccessDate { get; set; }
        public int DiagnosisId { get; set; }
        public Diagnosis Diagnosis { get; set; }
        public string DiagnosisNumber { get; set; }
        public string FamilyBio { get; set; }

        //LD
        public string? SchoolName { get; set; }
        public string? Class { get; set; }

    }
}
