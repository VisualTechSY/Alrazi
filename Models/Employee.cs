using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class Employee
    {
        [ForeignKey("Account")]
        public int Id { get; set; }
        public Account Account { get; set; }
        public string FullName { get; set; }
        public List<EmployeePermission> EmployeePermissions { get; set; }
    }
}