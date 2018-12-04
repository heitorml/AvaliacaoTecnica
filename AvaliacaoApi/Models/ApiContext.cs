using AvaliacaoApi.Models;
using Microsoft.EntityFrameworkCore;
namespace AvaliacaoApi.Models.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
          : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NumerosJogo>()
                .HasOne(d => d.Jogo)
                .WithMany(t => t.Numeros)
                .HasForeignKey("JogoId");

            modelBuilder.Entity<NumerosSorteio>()
                .HasOne(d => d.Sorteio)
                .WithMany(t => t.Numeros)
                .HasForeignKey("SorteioId");

            modelBuilder.Entity<Premiado>()
                .HasOne(d => d.Sorteio);            
           
            modelBuilder.Entity<Premiado>()
               .HasOne(d => d.JogoPremiado);

        }

        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<NumerosJogo> Numeros { get; set; }
        public DbSet<Sorteio> Sorteios { get; set; }
        public DbSet<NumerosSorteio> NumerosSorteio { get; set; }

        public DbSet<Premiado> Premiados { get; set; }
    }
}