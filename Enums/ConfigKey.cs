namespace Alrazi.Enums
{
    public enum ConfigKey
    {
        MinStudyDate,
    }

    public class ConfigKeyManager
    {
        public static string GetArabic(ConfigKey configKey)
        {
            switch (configKey)
            {
                case ConfigKey.MinStudyDate:
                    return "العمر الأدنى لدخول صعوبات التعلم";
                default:
                    return "";
            }
        }
    }
}
