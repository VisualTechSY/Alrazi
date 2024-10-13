using Alrazi.Enums;
using Alrazi.HttpParameters;
using Alrazi.Models;
using Alrazi.Tools;
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

        public async Task<Tuple<bool , string>> AddEmployee(NewEmployee newEmployee)
        {
            if (await AnyUserName(newEmployee.UserName))
                return Tuple.Create(false , "اسم المستخدم مكرر");

            await context.Employees.AddAsync(new Employee
            {
                FullName = newEmployee.FullName,
                Account = new Account
                {
                    UserName = newEmployee.UserName,
                    Password = newEmployee.UserName,
                    Picture = Cash.DefaultPicture,
                },
                EmployeePermissions = newEmployee.Permissions.Select(x=> new EmployeePermission
                {
                    Permission = x
                }).ToList()
            });
            await context.SaveChangesAsync();
            return Tuple.Create(true, "تمت الإضافة بنجاح");
        }

        public async Task<bool> AnyUserName(string username)
        {
            return await context.Accounts.AnyAsync(x => x.UserName == username);
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await context.Employees
                .Include(x => x.Account)
                .ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await context.Employees
                .Include(x => x.Account)
                .Include(x => x.EmployeePermissions)
                .FirstAsync(x=> x.Id == id);
        }

        public async Task EditEmployee(EditEmployee editEmployee)
        {
            var employee = await context.Employees.Include(x=> x.EmployeePermissions).FirstAsync(x=> x.Id == editEmployee.Id);
            employee.FullName = editEmployee.FullName;

            context.EmployeePermissions.RemoveRange(employee.EmployeePermissions);
            foreach (var item in editEmployee.Permissions)
            {
                await context.EmployeePermissions.AddAsync(new EmployeePermission
                {
                    EmployeeId = employee.Id,
                    Permission = item
                });
            }
            await context.SaveChangesAsync();
            
        }

        public async Task ResetPassword(int id)
        {
            var employee = await context.Accounts.FindAsync(id);
            employee.Password = employee.UserName;
            await context.SaveChangesAsync();
        }

        public async Task<Account> GetAccount(int id)
        {
            return await context.Accounts
                .Include(x=> x.Employee)
                .Include(x=> x.Employee.EmployeePermissions)
                .FirstAsync(x => x.Id == id);
        }
    }
}
