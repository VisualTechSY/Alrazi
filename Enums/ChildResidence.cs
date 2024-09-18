namespace Alrazi.Enums
{
    public enum ChildResidence
    {
        Father,
        Mother,
        All
    }

    public class ChildResidenceManager
    {
        public static string GetArabic(ChildResidence childResidence)
        {
            switch (childResidence)
            {
                case ChildResidence.Father:
                    return "الأب";
                case ChildResidence.Mother:
                    return "الأم";
                case ChildResidence.All:
                    return "كليهما";
                default:
                    return "";
            }
        }
    }
}
