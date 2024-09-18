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
        public DbSet<BehavioralProblem> BehavioralProblems { get; set; }
        public DbSet<Config> Configs { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeePermission> EmployeePermissions { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAbility> StudentAbilities { get; set; }
        public DbSet<StudentAcademic> StudentAcademics { get; set; }
        public DbSet<StudentAutonomy> StudentAutonomies { get; set; }
        public DbSet<StudentDevelopment> StudentDevelopments { get; set; }
        public DbSet<StudentEducationalَualification> StudentEducationals { get; set; }
        public DbSet<StudentFamilyActivity> StudentFamilyActivities { get; set; }
        public DbSet<StudentFamilyInfo> StudentFamilyInfos { get; set; }
        public DbSet<StudentInterests> StudentInterests { get; set; }
        public DbSet<StudentLevelInfo> StudentLevelInfos { get; set; }
        public DbSet<StudentMedical> StudentMedicals { get; set; }
        public DbSet<StudentMedicalTest> StudentMedicalTests { get; set; }
        public DbSet<StudentMistake> StudentMistakes { get; set; }
        public DbSet<StudentMotherMedical> StudentMotherMedicals { get; set; }
        public DbSet<StudentNote> StudentNotes { get; set; }
        public DbSet<StudentPotentialEnhancer> StudentPotentialEnhancers { get; set; }
        public DbSet<StudentPsychologyDevelopment> StudentPsychologyDevelopments { get; set; }
        public DbSet<StudentPsychologyDevelopmentBehavioralProblem> StudentPsychologyDevelopmentBehavioralProblems { get; set; }
        public DbSet<StudentSibling> StudentSiblings { get; set; }
        public DbSet<StudentSocialDevelopment> StudentSocialDevelopments { get; set; }
        public DbSet<StudentVisitCenter> StudentVisitCenters { get; set; }

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
