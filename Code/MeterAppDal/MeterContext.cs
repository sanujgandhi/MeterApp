using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MeterAppEntity.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MeterAppDal
{

    public class MeterContext : IdentityDbContext<ApplicationUser>
    {
        public MeterContext()
            : base("MeterContext")
        {
            Database.SetInitializer<MeterContext>(null);
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        #region To create all Dbset properties of model classes
        public DbSet<Project_Developer> Developer_Module { get; set; }
        public DbSet<Developer_Skill> Developer_Skill { get; set; }
        public DbSet<FileUpload> FileUpload { get; set; }
        public DbSet<GlobalCode> GlobalCode { get; set; }
        public DbSet<GlobalCodeCategory> GlobalCodeCategory { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Project_Module> Module { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Project_Technology> Project_Technology { get; set; }
        public DbSet<Screenshots> Screenshots { get; set; }
        public DbSet<WorkLogs> WorkLogs { get; set; }
        public DbSet<ProjectAssignments> ProjectAssignments { get; set; }
        #endregion

        public static MeterContext Create()
        {
            return new MeterContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();// remove pluralization of tables name.
            base.OnModelCreating(modelBuilder);
        }
    }
}
