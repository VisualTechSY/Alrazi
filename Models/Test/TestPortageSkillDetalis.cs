using Alrazi.Enums.Test;

namespace Alrazi.Models.Test
{
    public class TestPortageSkillDetalis
    {
        public int Id { get; set; }
        public int TestPortageSkillId { get; set; }
        public TestPortageSkill TestPortageSkill { get; set; }

        public TestPortage_Skill TestPortage_Skill { get; set; }
        public double Mark { get; set; }
    }
}
