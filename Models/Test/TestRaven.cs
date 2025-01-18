using Alrazi.Tools;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models.Test
{
    public class TestRaven
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [DisplayName("الرقم التسلسلي")]
        public int SerialNumber { get; set; }
        [DisplayName("القائم بالاختبار")]
        public string Examiner { get; set; }
        [DisplayName("مجموع العلامات")]
        public int Mark { get; set; }
        [DisplayName("تاريخ الفحص")]
        public DateTime TestDate { get; set; }

        [NotMapped]
        [DisplayName("الترتيب المئيني")]
        public int Centenary { get; set; }
        [NotMapped]
        [DisplayName("الدرجة")]
        public string ResaultIQ { get; set; }
        [NotMapped]
        [DisplayName("المسمى")]
        public string ResaultRank { get; set; }

        public void CalcResault()
        {
            if (Student is null) return;
            Centenary = TestRavenManager.GetRavenCentenary(Mark, new ViewModel.Birthday(Student.BirthDate, TestDate));
            ResaultIQ = TestRavenManager.GetTestRavenResaultIQ(Centenary);
            ResaultRank = TestRavenManager.GetTestRavenResaultRank(Centenary);
        }
    }
}
