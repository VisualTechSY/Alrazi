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
            return configKey switch
            {
                ConfigKey.EarlyRange => "نطاق عمر التدخل المبكر",
                ConfigKey.LDRange => "نطاق عمر صعوبات التعلم",
                ConfigKey.EQRange => "نطاق عمر التأهيل التربوي",
                _ => "",
            };
        }
    }
}
