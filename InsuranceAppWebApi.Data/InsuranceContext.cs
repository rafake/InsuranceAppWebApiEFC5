using InsuranceAppWebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace InsuranceAppWebApi.Data
{
    public class InsuranceContext: DbContext
    {
        public InsuranceContext(DbContextOptions<InsuranceContext> options):base(options)
        {

        }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<InsuranceCompany> InsuranceCompanies { get; set; }
        public DbSet<Insuree> Insurees { get; set; }

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
