using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata;
using Alrazi.Models;
using Alrazi.Tools;

namespace Alrazi
{
    public class Context : DbContext
    {
        public DbSet<AccessChannel> AccessChannels { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeePermission> EmployeePermissions { get; set; }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public static Context GetNew()
        {
            DbContextOptionsBuilder<Context> dbContextOptionsBuilder = new DbContextOptionsBuilder<Context>();
            dbContextOptionsBuilder.UseSqlServer(JsonManager.GetConnectionString());
            return new Context(dbContextOptionsBuilder.Options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            IEnumerable<IMutableForeignKey> enumerable = from fk in modelBuilder.Model.GetEntityTypes().SelectMany((IMutableEntityType t) => t.GetForeignKeys())
                                                         where !fk.IsOwnership && (int)fk.DeleteBehavior == 3
                                                         select fk;
            foreach (IMutableForeignKey item in enumerable)
            {
                item.DeleteBehavior = (DeleteBehavior)1;
            }

            //modelBuilder.Entity<LevelYearSessionTime>()
            //    .HasMany(l => l.ProgramWeeks)
            //    .WithOne(p => p.LevelYearSessionTime)
            //    .HasForeignKey(p => p.LevelYearSessionTimeId)
            //    .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
    //we need this class in design time for update database, but in run time we do not need it
    public class SiteContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseSqlServer();
            return new Context(optionsBuilder.Options);
        }

    }
}
