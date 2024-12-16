using Microsoft.EntityFrameworkCore;

namespace InvestmentsApp.Backend.Models
{
    public class InvestmentsAppContext : DbContext
    {
        public InvestmentsAppContext(DbContextOptions<InvestmentsAppContext> options)
            : base(options) { }

        public DbSet<Investment> Investments { get; set; }
        public DbSet<TypeInvestment> TypeInvestments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Investment>()
                .HasIndex(i => i.Ticker);

        }
    }
}
