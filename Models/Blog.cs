namespace Alrazi.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string ShortDetails { get; set; }
        public bool IsPin { get; set; }
        public DateTime PostDate { get; set; }
        public List<BlogFile> BlogFiles { get; set; }
    }
}
