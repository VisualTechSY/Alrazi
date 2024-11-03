namespace Alrazi.ViewModel
{
    public class StudentTestReportVM
    {
        //اسم الطفل
        public string StudentName { get; set; }
        //المواليد
        public DateTime BirthDate { get; set; }
        //رقم التقييم
        public int SerialNumber { get; set; }
        //تاريخ التقييم
        public DateTime TestDate { get; set; }
        //الزمني بالأشهر
        public int AgeInMonths { get; set; }
        //العمر الزمني
        public double Age { get; set; }
        //المجالات
        public string Subject { get; set; }
        //القاعدي
        public double NumberCorrectAnswers { get; set; }
        //الاضافي
        public int Additional { get; set; }
        // النمائي بالأشهر
        public int DevelopmentalAgeOfMounth { get; set; }
        //العمر النمائي
        public double DevelopmentalAge { get; set; }
        //نسبة الاداء%
        public double PerformancePercentage { get; set; }
        //نسبة الاداء كتابة
        public string PerformanceDegree { get; set; }
        //الفرق بالأشهر  بين ز - ن
        public double DifferenceInMonths { get; set; }
        //الفرق بالسنوات
        public double DifferenceInYear { get; set; }
        //التحقق
        public double Verification { get; set; }
        //المجموع
        public double TotalMarks { get; set; }
        //التصنيف
        public double RatingPercentage { get; set; }
        //التصنيف
        public string RatingDegree { get; set; }
        //العمر الزمني
        public double ChronologicalAge { get; set; }
    }
}
