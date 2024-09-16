namespace Alrazi.Models
{
    public class Nationality
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string State => IsActive ? "متاحة" : "غير متاحة";
    }
}