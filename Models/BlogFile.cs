using System.Text.Json.Serialization;

namespace Alrazi.Models
{
    public class BlogFile
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        [JsonIgnore]
        public Blog Blog { get; set; }
        public string Url { get; set; }
        public bool IsIamge { get; set; }
    }
}