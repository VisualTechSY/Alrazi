using Alrazi.Enums.Test;
using System.ComponentModel;

namespace Alrazi.Models.Test
{
	public class TestPortageSkill
	{
		public int Id { get; set; }
		public int TestPortageId { get; set; }
		public TestPortage TestPortage { get; set; }

		public TestPortage_Skill TestPortage_Skill { get; set; }

		public double Mark { get; set; }
	}
}
