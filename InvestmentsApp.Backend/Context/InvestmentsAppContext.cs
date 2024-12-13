using InvestmentsApp.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace InvestmentsApp.Backend.Context
{
    public class InvestmentsAppContext : DbContext
    {
        public InvestmentsAppContext(DbContextOptions<InvestmentsAppContext> options)
            : base(options) { }

        public DbSet<Investmetn> Investmetns { get; set; }
        public DbSet<TypeInvestment> TypeInvestments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Investmetn>()
                .HasIndex(i => i.Tikcker);

        }
    }
}
