namespace Alrazi.ViewModel
{
    public class Birthday
    {
        public Birthday(DateTime birthdate, DateTime currentDate) => GetAgeDateTime(birthdate, currentDate);

        public int AgeYears { get; set; }
        public int AgeMonths { get; set; }
        public int AgeDays { get; set; }

        public int TotalMonth => (AgeYears * 12 + AgeMonths);
        //العمر الزمني  مثل 7.3
        public string ChronologicalAge => (AgeYears + "," + AgeMonths);
        public override string ToString()
        {
            return "السنة: " + AgeYears + "- الشهر : " + AgeMonths + "-اليوم " + AgeDays;
        }


        //تعيد العمر بالسنوات والأشهر والأيام
        public void GetAgeDateTime(DateTime birthdate, DateTime currentDate)
        {
            AgeYears = currentDate.Year - birthdate.Year;
            AgeMonths = currentDate.Month - birthdate.Month;
            AgeDays = currentDate.Day - birthdate.Day;

            if (AgeDays < 0)
            {
                AgeMonths--;
                int PrevMonth = new DateTime(currentDate.Year, currentDate.Month, 1).AddMonths(-1).Month;
                AgeDays += DateTime.DaysInMonth(currentDate.Year, PrevMonth);
            }

            if (AgeMonths < 0)
            {
                AgeYears--;
                AgeMonths += 12;
            }

        }
    }
}
