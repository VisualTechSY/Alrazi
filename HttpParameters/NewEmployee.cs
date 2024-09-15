using Alrazi.Enums;

namespace Alrazi.HttpParameters
{
    public class NewEmployee
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public Permission[] Permissions { get; set; }
    }
}
