namespace Alrazi.Models
{
    public class BehavioralProblem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string State => IsActive ? "متاحة" : "غير متاحة";
    }
}