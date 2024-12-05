using System.ComponentModel;

namespace Alrazi.Models.Test
{
    public class TestPortage
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [DisplayName("الرقم التسلسلي")]
        public int SerialNumber { get; set; }
        [DisplayName("الفاحص")]
        public string Examiner { get; set; }
        [DisplayName("مرفق بالاختبار")]
        public string Attendant { get; set; }
        [DisplayName("تاريخ المقابلة")]
        public DateTime TestDate { get; set; }

        [DisplayName("تاريخ قائمة الشطب")]
        public DateTime TestDateSkill { get; set; }

        [DisplayName("خلاصة")]
        public string Summary { get; set; }
        [DisplayName("توصيات")]
        public string Recommendations { get; set; }

        public List<TestPortageDetails> TestPortageDetails { get; set; }
        public List<TestPortageSkill> TestPortageSkills { get; set; }
    }


}
