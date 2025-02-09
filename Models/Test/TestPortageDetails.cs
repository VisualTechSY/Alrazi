using Alrazi.Enums.Test;
using Alrazi.Tools;
using Alrazi.ViewModel;
using System.ComponentModel;

namespace Alrazi.Models.Test
{
    public class TestPortageDetails
    {
        /// <summary>
        /// الصورة الجانبية
        /// </summary>
        public int Id { get; set; }

        public int TestPortageId { get; set; }
        public TestPortage TestPortage { get; set; }

        [DisplayName("المجالات")]
        public TestPortageSubject TestPortageSubject { get; set; }

        [DisplayName("القاعدي")]
        public string AgeTheBase { get; set; }
        [DisplayName("الاضافي")]
        public int AgeAddonal { get; set; }
        [DisplayName("النمائي")]
        public string AgeGrowth => Birthday.CalcAgeAddMonth(AgeTheBase, AgeAddonal);
        [DisplayName("الدرجة")]
        public int Mark { get; set; }

        [DisplayName("التصنيف")]
        public string Grade => TestManager.GetTestPortageResault(Mark);

        //العمر النمائي بالسنوات والأشهر
        public string AgeGrowthYear => AgeGrowthCalcYear();
        public string AgeGrowthMonth => AgeGrowthCalcMonth();


        string AgeGrowthCalcYear()
        {
            var age= AgeGrowth.Split('.');
            return age[0];
        } 
         string AgeGrowthCalcMonth()
        {
            var age= AgeGrowth.Split('.');
            return (age.Length>1)? age[1]:"0";
        }

    }
}
