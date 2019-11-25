using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace Praha20191113.Web.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<Movie> Movies { get; set; }
        public IDbSet<Language> Language { get; set; }
        public IDbSet<Log> Log { get; set; }
    }
}