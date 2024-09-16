using Alrazi.Enums;

namespace Alrazi.Models
{
    public class Config
    {
        public int Id { get; set; }
        public ConfigKey ConfigKey { get; set; }
        public string Value { get; set; }
    }
}