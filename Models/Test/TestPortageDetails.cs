using Alrazi.Enums.Test;
using Alrazi.Tools;
using System.ComponentModel;

namespace Alrazi.Models.Test
{
    public class TestPortageDetails
    {
        public int Id { get; set; }

        public int TestPortageId { get; set; }
        public TestPortage TestPortage { get; set; }

        public TestPortageSubject TestPortageSubject { get; set; }

        [DisplayName("القاعدي")]
        public string AgeTheBase { get; set; }
        [DisplayName("الاضافي")]
        public string AgeAddonal { get; set; }
        [DisplayName("النمائي")]
        public string AgeGrowth { get; set; }
        [DisplayName("الدرجة")]
        public int Mark { get; set; }

        [DisplayName("التصنيف")]
        public string Grade => TestManager.GetTestPortageResault(Mark);
    }
}
