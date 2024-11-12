using System.ComponentModel;

namespace Alrazi.Models.Test
{
    public class TestPortage
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [DisplayName("الفاحص")]
        public string Examiner { get; set; }
        [DisplayName("مرفق بالاختبار")]
        public string Attendant { get; set; }
        [DisplayName("تاريخ المقابلة")]
        public DateTime TestDate { get; set; }


        public List<TestPortageDetails> TestPortageDetails { get; set; }
    }


}
