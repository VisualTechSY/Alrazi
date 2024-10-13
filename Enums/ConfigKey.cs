namespace Alrazi.Enums
{
    public enum ConfigKey
    {
        EarlyRange,
        LDRange,
        EQRange,
    }

    public class ConfigKeyManager
    {
        public static string GetArabic(ConfigKey configKey)
        {
            switch (configKey)
            {
                case ConfigKey.EarlyRange:
                    return "نطاق عمر التدخل المبكر";
                case ConfigKey.LDRange:
                    return "نطاق عمر صعوبات التعلم";
                case ConfigKey.EQRange:
                    return "نطاق عمر التأهيل التربوي";
                default:
                    return "";
            }
        }
    }
}
