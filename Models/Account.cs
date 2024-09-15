namespace Alrazi.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Picture { get; set; }
        public Employee Employee { get; set; }
    }
}