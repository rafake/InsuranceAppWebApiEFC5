using InsuranceAppWebApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace InsuranceAppWebApi.Data
{
    public class InsuranceContext: DbContext
    {
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<InsuranceCompany> InsuranceCompanies { get; set; }
        public DbSet<Insuree> Insurees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //logging enabled
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=InsuranceAppWebApiData")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Insurance>()
                .HasMany(s => s.Insurees)
                .WithMany(i => i.Insurances)
                .UsingEntity<InsureeInsurance>
                (ii => ii.HasOne<Insuree>().WithMany(),
                 ii => ii.HasOne<Insurance>().WithMany())
                .Property(ii => ii.DateJoined)
                .HasDefaultValueSql("getdate()");
        }
    }
}
