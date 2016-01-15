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
    public class ApplicationUser : IdentityUser
    {

        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Level { get; set; }
        public DateTime JoinDate { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager ,string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            //var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
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
        public DbSet<Developer_Module> Developer_Module { get; set; }
        public DbSet<Developer_Skill> Developer_Skill { get; set; }
        public DbSet<FileUpload> FileUpload { get; set; }
        public DbSet<GlobalCode> GlobalCode { get; set; }
        public DbSet<GlobalCodeCategory> GlobalCodeCategory { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Project_Skill> Project_Skill { get; set; }
        public DbSet<Project_Technology> Project_Technology { get; set; }
        public DbSet<Screenshots> Screenshots { get; set; }
        public DbSet<WorkLogs> WorkLogs { get; set; }
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
