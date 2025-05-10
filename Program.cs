using Alrazi;
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
builder.Services.AddTransient<TestService>();
builder.Services.AddTransient<WebsiteService>();

builder.Services.AddHostedService<CheckIdel>();

var app = builder.Build();

var context = Context.GetNew();
//await context.Database.EnsureDeletedAsync();
await context.Database.MigrateAsync();

if (!context.Accounts.Any())
{
    SeedDB seedDB = new(context);
    await seedDB.FirstBuildDB();
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