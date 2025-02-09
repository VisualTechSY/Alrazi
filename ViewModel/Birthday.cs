namespace Alrazi.ViewModel
{
    public class Birthday
    {
        public Birthday(DateTime birthdate, DateTime currentDate) => GetAgeDateTime(birthdate, currentDate);

        public int Years { get; set; }
        public int Months { get; set; }
        public int Days { get; set; }

        public int TotalMonth => (Years * 12 + Months);

        //public double CalcAge
        //{
        //    //todo round Days>25
        //    get { return (Years + Months * 0.084); }
        //}
        public override string ToString()
        {
            return Years + " سنوات ," + Months + " أشهر ," + Days + " أيام";
        }


        //تحسب العمر بالسنوات والأشهر والأيام
        public void GetAgeDateTime(DateTime birthdate, DateTime currentDate)
        {
            Years = currentDate.Year - birthdate.Year;
            Months = currentDate.Month - birthdate.Month;
            Days = currentDate.Day - birthdate.Day;

            if (Days < 0)
            {
                Months--;
                int PrevMonth = new DateTime(currentDate.Year, currentDate.Month, 1).AddMonths(-1).Month;
                Days += DateTime.DaysInMonth(currentDate.Year, PrevMonth);
            }

            if (Months < 0)
            {
                Years--;
                Months += 12;
            }

        }

        //العمر الزمني  مثل 7.3
        public string GetDecimalAge
        {
            //todo round Days>25
            get { return (Years + "," + Months); }
        }
        public static int ConvertFromDecimalToMonth(string decimalAge)
        {
            var age = decimalAge.Split('.');

            int year = 0, month = 0;

            _ = int.TryParse(age[0], out year);

            if (age.Length > 1)
                _ = int.TryParse(age[1], out month);

            return year * 12 + month;
        }
        public static string CalcAgeGrowth(string AgeTheBase, int AgeAddonal)
        {
            int totalMonth = ConvertFromDecimalToMonth(AgeTheBase);

            if (totalMonth == 0) return "";

            totalMonth += AgeAddonal;
            return ((totalMonth / 12) + "," + (totalMonth % 12));
        }
    }
}
