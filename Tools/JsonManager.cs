using Newtonsoft.Json;

namespace Alrazi.Tools
{
    public class JsonManager
    {
        private static IConfigurationRoot? configuration;

        public static void SetJeson()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
            configuration = configurationBuilder.Build();
        }

        public static string GetConnectionString()
        {
            return configuration.GetConnectionString("DefaultConnection");
        }

        public static string GetSection(string name)
        {
            return configuration.GetSection(name).Value;
        }

        public static T ConvertToObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
