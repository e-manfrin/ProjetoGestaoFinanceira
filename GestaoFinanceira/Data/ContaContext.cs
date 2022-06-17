using GestaoFinanceira.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoFinanceira.Data
{
    public class ContaContext : DbContext
    {
        public ContaContext(DbContextOptions<ContaContext> opt) : base(opt)
        {

        }
        public DbSet<Conta> Contas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Conta>()
                .HasData(new List<Conta>()
                {
                    new Conta(1,DateTime.Now,100,"Pago"),
                    new Conta(2,DateTime.Now,700,"Pago"),
                    new Conta(3,DateTime.Now,50,"Pago"),
                });
        }
    }
}

