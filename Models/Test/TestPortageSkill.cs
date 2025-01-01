using Alrazi.Enums.Test;
using System.ComponentModel;

namespace Alrazi.Models.Test
{
	public class TestPortageSkill
	{
		/// <summary>
		/// قائمة الشطب
		/// </summary>
		public int Id { get; set; }
		public int TestPortageId { get; set; }
		public TestPortage TestPortage { get; set; }

        public int SerialNumber { get; set; }
        public DateTime TestDateSkill { get; set; }

        public List<TestPortageSkillDetalis> TestPortageSkillDetalis { get; set; }
    }
}
