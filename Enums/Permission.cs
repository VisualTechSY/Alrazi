namespace Alrazi.Enums
{
    public enum Permission
    {
        Login,
        ManageEmployee
    }

    public class PermissionManager
    {
        public static string GetArabic(Permission permission)
        {
            switch (permission)
            {
                case Permission.Login:
                    return "تسجيل الدخول";
                case Permission.ManageEmployee:
                    return "إدارة الموظفين";
                default:
                    return "";
            }
        }
    }
}
