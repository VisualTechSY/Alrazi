using Alrazi.Enums;
using Alrazi.Models;
using Microsoft.EntityFrameworkCore;

namespace Alrazi.Services
{
    public class AccountService(Context context)
    {
        public async Task<Tuple<Account,string>> Login(string username , string password)
        {
            var account = await context.Accounts
                .Include(x => x.Employee)
                .Include(x => x.Employee.EmployeePermissions)
                .FirstOrDefaultAsync(x => x.UserName == username && x.Password == password);
            if (account is null)
                return Tuple.Create(new Account() , "خطأ بمعلومات الدخول");
            if (!account.Employee.EmployeePermissions.Any(x => x.Permission == Permission.Login))
                return Tuple.Create(new Account(), "الحساب معطل");
            return Tuple.Create(account, string.Empty);
        }


    }
}
