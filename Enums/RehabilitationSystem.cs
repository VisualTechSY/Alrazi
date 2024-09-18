namespace Alrazi.Enums
{
    public enum RehabilitationSystem
    {
        IndividualSessions,
        Class
    }

    public class RehabilitationSystemManager
    {
        public static string GetArabic(RehabilitationSystem rehabilitationSystem)
        {
            switch (rehabilitationSystem)
            {
                case RehabilitationSystem.IndividualSessions:
                    return "جلسات فردية";
                case RehabilitationSystem.Class:
                    return "صف";
                default:
                    return "";
            }
        }
    }
}
