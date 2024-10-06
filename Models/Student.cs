using Alrazi.Enums;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Alrazi.Models
{
	public class Student
	{
		public int Id { get; set; }
		public StudentStatus StudentStatus { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int StateNumber { get; set; }
		public string BirthPlace { get; set; }
		public DateTime BirthDate { get; set; }
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


		public StudentFamilyInfo StudentFamilyInfo { get; set; }
		public StudentMotherMedical StudentMotherMedical { get; set; }
		public StudentMedical StudentMedical { get; set; }
		public StudentMedicalTest StudentMedicalTest { get; set; }
		public StudentDevelopment StudentDevelopment { get; set; }
		public StudentPsychologyDevelopment StudentPsychologyDevelopment { get; set; }
		public StudentSocialDevelopment StudentSocialDevelopment { get; set; }
		public StudentAutonomy StudentAutonomy { get; set; }
		public StudentFamilyActivity StudentFamilyActivity { get; set; }
		public StudentPotentialEnhancer StudentPotentialEnhancer { get; set; }
		public StudentNote StudentNote { get; set; }
		public StudentAcademic StudentAcademic { get; set; }
		public StudentAbility StudentAbility { get; set; }
		public List<StudentSibling> StudentSiblings { get; set; }
		public List<StudentInterests> StudentInterests { get; set; }
		public List<StudentLevelInfo> StudentLevelInfos { get; set; }
		public List<StudentVisitCenter> StudentVisitCenters { get; set; }
		public List<StudentEducationalualification> StudentEducationalualifications { get; set; }

		//public string GetAgeDateTime()
		//{
		//    DateTime birthdate = new DateTime(BirthDate.Year, BirthDate.Month, BirthDate.Day);
		//    DateTime currentdate = new DateTime(StudyStateDate.Year, StudyStateDate.Month, StudyStateDate.Day);
		//    DateTime newDate = currentdate.AddDays(-birthdate.Day).AddMonths(-birthdate.Month).AddYears(-birthdate.Year);

		//    return $"العام : {newDate.Year} - الشهر : {newDate.Month} - اليوم : {newDate.Day}";
		//}

		public int GetAge()
		{
			DateTime birthdate = new(BirthDate.Year, BirthDate.Month, BirthDate.Day);
			DateTime currentdate = new(StudyStateDate.Year, StudyStateDate.Month, StudyStateDate.Day);
			return (currentdate - birthdate).Days / 365;
		}

	}
}