namespace Alrazi.Enums
{
    public enum Focus
    {
        Good,
        Normal,
        Middle
    }

    public class FocusManager
    {
        public static string GetArabic(Focus focus)
        {
            switch (focus)
            {
                case Focus.Good:
                    return "جيدة";
                case Focus.Normal:
                    return "عادية";
                case Focus.Middle:
                    return "وسط";
                default:
                    return "";
            }
        }
    }
}
