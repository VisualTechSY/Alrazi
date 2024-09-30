using Alrazi.Enums;
using Microsoft.Extensions.FileSystemGlobbing;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentFamilyInfo
    {
        [ForeignKey("Student")]
        public int Id { get; set; }
        public Student Student { get; set; }
        public string MotherName { get; set; }
        public DateTime MotherBirthDate { get; set; }
        public string MotherStudy { get; set; }
        public string MotherJob { get; set; }
        public string FatherName { get; set; }
        public DateTime FatherBirthDate { get; set; }
        public string FatherStudy { get; set; }
        public string FatherJob { get; set; }
        public DateTime MotherAgeAtBirth { get; set; }
        public string FatherAndMotherDegree { get; set; }
        public string FatherAndMotherDiseases { get; set; }
        public string DisabilityOfRelative { get; set; }
        public string RelationshipWithDisabled { get; set; }
        public int BrotherAndSisterCount { get; set; }
        public int ChildOrder { get; set; }

        //LD
        public bool? SeparatedParents { get; set; }
        public ChildResidence? ChildResidence { get; set; }


        public int GetMotherYear => MotherBirthDate == default ? 0 : DateTime.Now.Year - MotherBirthDate.Year;
        [NotMapped]
        public int MotherYear { get; set; }

        public int GetFatherYear => FatherBirthDate == default ? 0 : DateTime.Now.Year - FatherBirthDate.Year;
        [NotMapped]
        public int FatherYear { get; set; }

        public int GetMotherAtBirthYear => MotherAgeAtBirth == default ? 0 : DateTime.Now.Year - MotherAgeAtBirth.Year;
        [NotMapped]
        public int MotherAtBirthYear { get; set; }

    }
}
