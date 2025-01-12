namespace Alrazi.ViewModel
{
    public class Birthday
    {
        public Birthday(DateTime birthdate, DateTime currentDate) => GetAgeDateTime(birthdate, currentDate);

        public int Years { get; set; }
        public int Months { get; set; }
        public int Days { get; set; }

        public int TotalMonth => (Years * 12 + Months);
        //العمر الزمني  مثل 7.3
        public string ChronologicalAge
        {
            //todo round Days>25
            get { return (Years + "," + Months); }
        }
        public double CalcAge
        {
            //todo round Days>25
            get { return (Years + Months * 0.084); }
        }
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
    }
}
