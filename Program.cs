using Alrazi;
using Alrazi.Enums;
using Alrazi.Models;
using Alrazi.Services;
using Alrazi.Tools;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(delegate (SessionOptions options)
{
    options.IdleTimeout = TimeSpan.FromHours(2.0);
});
JsonManager.SetJeson();

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(JsonManager.GetConnectionString()),
    ServiceLifetime.Transient);

builder.Services.AddTransient<AccountService>();
builder.Services.AddTransient<ConfigService>();
builder.Services.AddTransient<StudentService>();

builder.Services.AddHostedService<CheckIdel>();

var app = builder.Build();

var context = Context.GetNew();
//await context.Database.EnsureDeletedAsync();
await context.Database.MigrateAsync();

if (!context.Accounts.Any())
{
    await context.Accounts.AddAsync(new Account
    {
        UserName = "admin",
        Password = "admin",
        Picture = "https://cdn-icons-png.flaticon.com/512/219/219983.png",
        Employee = new Employee
        {
            FullName = "Alaa Alkhawam",
            EmployeePermissions = Enum.GetValues<Permission>().Select(x=> new Alrazi.Models.EmployeePermission
            {
                Permission = x
            }).ToList()
        }
    });
    await context.SaveChangesAsync();
}

foreach (var item in Enum.GetValues<ConfigKey>())
{
    if (!context.Configs.Any(x=> x.ConfigKey == item))
    {
        await context.Configs.AddAsync(new Config
        {
            ConfigKey = item,
            Value = "0"
        });
    }
    await context.SaveChangesAsync();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();