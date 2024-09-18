namespace Alrazi.Enums
{
    public enum Interests
    {
        Games,
        Foods,
        Places,
        Persons,
        Actions
    }

    public class InterestsManager
    {
        public static string GetArabic(Interests interests)
        {
            switch (interests)
            {
                case Interests.Games:
                    return "ألعاب";
                case Interests.Foods:
                    return "طعمة";
                case Interests.Places:
                    return "أماكن";
                case Interests.Persons:
                    return "أشخاص";
                case Interests.Actions:
                    return "مثيرات حسية";
                default:
                    return "";
            }
        }
    }
}
