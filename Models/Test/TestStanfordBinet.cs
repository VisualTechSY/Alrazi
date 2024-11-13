using Alrazi.ViewModel;
using System.ComponentModel;

namespace Alrazi.Models.Test
{
    public class TestStanfordBinet
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [DisplayName("الرقم التسلسلي")]
        public int SerialNumber { get; set; }
        [DisplayName("الفاحص")]
        public string Examiner { get; set; }
        [DisplayName("تاريخ التقرير")]
        public DateTime TestDate { get; set; }

        public List<TestStanfordBinetDetails> TestStanfordBinetDetails { get; set; }

    }
}
