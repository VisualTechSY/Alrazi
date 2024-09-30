using System.ComponentModel;

namespace Alrazi.Tools
{
    public class DataTypeExtention
    {
        public static string GetStringFromDate(DateTime dateTime)
        {
            string date = "";
            date += dateTime.Year + "-";
            if (dateTime.Month <= 9)
                date += "0";
            date += +dateTime.Month + "-";
            if (dateTime.Day <= 9)
                date += "0";
            date += +dateTime.Day;
            return date;
        }

        public static string GetDisplayName<T>(string propertyName)
        {
            var propertyInfo = typeof(T).GetProperty(propertyName);
            if (propertyInfo != null)
            {
                var displayNameAttribute = propertyInfo
                    .GetCustomAttributes(typeof(DisplayNameAttribute), false)
                    .FirstOrDefault() as DisplayNameAttribute;

                return displayNameAttribute?.DisplayName ?? propertyName;
            }

            return propertyName;
        }
    }
}
