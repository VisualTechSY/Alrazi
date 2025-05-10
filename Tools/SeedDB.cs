using Alrazi.Enums;
using Alrazi.Models;

namespace Alrazi.Tools
{
    public class SeedDB(Context context)
    {
        readonly Context context = context;

        public async Task FirstBuildDB()
        {
            await context.Accounts.AddAsync(new Account
            {
                UserName = "admin",
                Password = "admin",
                Picture = "https://cdn-icons-png.flaticon.com/512/219/219983.png",
                Employee = new Employee
                {
                    FullName = "مدير النظام",
                    EmployeePermissions = Enum.GetValues<Permission>().Select(x => new EmployeePermission
                    {
                        Permission = x
                    }).ToList()
                }
            });

            await context.Configs.AddAsync(new Config { ConfigKey = ConfigKey.EarlyRange, Value = "1-6" });
            await context.Configs.AddAsync(new Config { ConfigKey = ConfigKey.LDRange, Value = "6-12" });
            await context.Configs.AddAsync(new Config { ConfigKey = ConfigKey.EQRange, Value = "13-60" });

            await context.Diagnoses.AddAsync(new Diagnosis { Name = "توحد", IsActive = true });
            await context.Diagnoses.AddAsync(new Diagnosis { Name = "صعوبات", IsActive = true });
            await context.Diagnoses.AddAsync(new Diagnosis { Name = "النطق", IsActive = true });
            await context.Diagnoses.AddAsync(new Diagnosis { Name = "تدخل", IsActive = true });

            await context.BehavioralProblems.AddAsync(new BehavioralProblem { Name = "اضطرابات النمائية", IsActive = true });
            await context.BehavioralProblems.AddAsync(new BehavioralProblem { Name = "فرط النشاط", IsActive = true });
            await context.BehavioralProblems.AddAsync(new BehavioralProblem { Name = "التوحد", IsActive = true });
            await context.BehavioralProblems.AddAsync(new BehavioralProblem { Name = "يقضم اظافره", IsActive = true });
            await context.BehavioralProblems.AddAsync(new BehavioralProblem { Name = "يمص اصابعه", IsActive = true });
            await context.BehavioralProblems.AddAsync(new BehavioralProblem { Name = "عدوانية", IsActive = true });

            await context.Nationalities.AddAsync(new Nationality { Name = "سوري", IsActive = true });

            await context.SaveChangesAsync();
        }
    }
}
