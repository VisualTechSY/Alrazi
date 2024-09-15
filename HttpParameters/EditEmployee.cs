using Alrazi.Enums;

namespace Alrazi.HttpParameters
{
    public class EditEmployee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public Permission[] Permissions { get; set; }
    }
}
