using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentPsychologyDevelopmentBehavioralProblem
    {
        public int Id { get; set; }
        public int BehavioralProblemId { get; set; }
        public BehavioralProblem BehavioralProblem { get; set; }
        public int StudentPsychologyDevelopmentId { get; set; }
        public StudentPsychologyDevelopment StudentPsychologyDevelopment { get; set; }

    }
}
