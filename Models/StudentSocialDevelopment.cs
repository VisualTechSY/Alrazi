using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentSocialDevelopment
    {
        [ForeignKey("Student")]
        public int Id { get; set; }
        public Student Student { get; set; }
        public string VisualCommunication { get; set; }
        public string IntentionalCommunication { get; set; }
        public string FacialExpressions { get; set; }
        public string Play { get; set; }
        public string Interaction { get; set; }

        //Early
        public string? ChildRelationships { get; set; }

        //LD
        public string HouseHelp { get; set; }

    }
}
