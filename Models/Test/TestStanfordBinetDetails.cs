using Alrazi.Enums.Test;
using Alrazi.Tools;
using System.ComponentModel;

namespace Alrazi.Models.Test
{
    public class TestStanfordBinetDetails
    {
        public int Id { get; set; }
        public int TestStanfordBinetId { get; set; }
        public TestStanfordBinet TestStanfordBinet { get; set; }

        [DisplayName("الدرجة")]
        public TestStanfordBinetSubject TestStanfordBinetSubject { get; set; }
        [DisplayName("الدرجة المعيارية")]
        public int Mark { get; set; }
        [DisplayName("الفئة التصنيفية")]
        public string Grade => TestManager.GetTestStanfordBinetResault(Mark);
        [DisplayName("الرتبة المئينية")]
        public int PercentileRank { get; set; } 
        [DisplayName("حدود الثقة عند مستوى لثقة 95%")]
        public string ConfidenceLimits { get; set; }

    }
}
