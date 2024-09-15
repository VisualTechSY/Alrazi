using Alrazi.Enums;
using Alrazi.Models;

namespace Alrazi.Tools
{
    public static class SessionManager
    {
        public static bool HasSession(this HttpContext httpContext) => httpContext.Session.GetInt32("Id").HasValue;
        public static int GetMyId(this HttpContext httpContext) => httpContext.Session.GetInt32("Id").Value;
        public static bool HasPermission(this HttpContext httpContext , Permission permission) => httpContext.Session.GetInt32(permission.ToString()).HasValue;
        public static string GetMyPicture(this HttpContext httpContext) => httpContext.Session.GetString("Picture");
        public static string GetMyName(this HttpContext httpContext) => httpContext.Session.GetString("FullName");


        public static void SetSession(this HttpContext httpContext , Account account)
        {
            httpContext.Session.SetInt32("Id", account.Id);
            httpContext.Session.SetString("FullName", account.Employee.FullName);
            httpContext.Session.SetString("Picture", account.Picture);

            foreach (var item in account.Employee.EmployeePermissions)
                httpContext.Session.SetInt32(item.Permission.ToString(), 1);
        }

        public static void RemoveSession(this HttpContext httpContext)
        {
            httpContext.Session.Clear();
        }
    }
}
