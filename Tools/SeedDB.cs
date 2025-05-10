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
                    FullName = "Alaa Alkhawam",
                    EmployeePermissions = Enum.GetValues<Permission>().Select(x => new Alrazi.Models.EmployeePermission
                    {
                        Permission = x
                    }).ToList()
                }
            });

            await context.Configs.AddAsync(new Config { ConfigKey = ConfigKey.EarlyRange, Value = "1-6" });
            await context.Configs.AddAsync(new Config { ConfigKey = ConfigKey.LDRange, Value = "6-12" });
            await context.Configs.AddAsync(new Config { ConfigKey = ConfigKey.EQRange, Value = "13-60" });

            await context.Diagnoses.AddAsync(new Diagnosis { Id = 1, Name = "توحد", IsActive = true });
            await context.Diagnoses.AddAsync(new Diagnosis { Id = 2, Name = "صعوبات", IsActive = true });
            await context.Diagnoses.AddAsync(new Diagnosis { Id = 3, Name = "النطق", IsActive = true });
            await context.Diagnoses.AddAsync(new Diagnosis { Id = 4, Name = "تدخل", IsActive = true });

            await context.BehavioralProblems.AddAsync(new BehavioralProblem { Id = 1, Name = "اضطرابات النمائية", IsActive = true });
            await context.BehavioralProblems.AddAsync(new BehavioralProblem { Id = 2, Name = "فرط النشاط", IsActive = true });
            await context.BehavioralProblems.AddAsync(new BehavioralProblem { Id = 3, Name = "التوحد", IsActive = true });
            await context.BehavioralProblems.AddAsync(new BehavioralProblem { Id = 4, Name = "يقضم اظافره", IsActive = true });
            await context.BehavioralProblems.AddAsync(new BehavioralProblem { Id = 5, Name = "يمص اصابعه", IsActive = true });
            await context.BehavioralProblems.AddAsync(new BehavioralProblem { Id = 6, Name = "عدوانية", IsActive = true });

            await context.Nationalities.AddAsync(new Nationality { Name = "سوري", IsActive = true });

            await context.SaveChangesAsync();
        }
    }
}
