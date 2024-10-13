namespace Alrazi.Enums
{
    public enum BirthType
    {
        Natural,
        Caesarean,
        Machines
    }

    public class BirthTypeManager
    {
        public static string GetArabic(BirthType birthType)
        {
            switch (birthType)
            {
                case BirthType.Natural:
                    return "طبيعية";
                case BirthType.Caesarean:
                    return "قيصرية";
                case BirthType.Machines:
                    return "بإستخدام آلات";
                default:
                    return "";
            }
        }
    }
}
