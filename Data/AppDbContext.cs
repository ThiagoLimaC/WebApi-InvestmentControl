using Microsoft.EntityFrameworkCore;
using WebApi_InvestmentControl.Models;

namespace WebApi_InvestmentControl.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<InvestimentoModel> Investimentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvestimentoModel>()
                .Property(i => i.Valor)
                .HasPrecision(18, 2);
        }
    }
}
