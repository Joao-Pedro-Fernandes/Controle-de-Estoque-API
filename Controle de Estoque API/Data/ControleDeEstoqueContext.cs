using Controle_de_Estoque_API.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace Controle_de_Estoque_API.Data
{
    public class ControleDeEstoqueContext : DbContext
    {
        public ControleDeEstoqueContext(DbContextOptions<ControleDeEstoqueContext> options) : base(options)
        {
        }

        public DbSet<Peca> Pecas { get; set; }
        public DbSet<CompatibilidadePeca> CompatibilidadePecas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompatibilidadePeca>()
                .HasOne(cp => cp.Peca)
                .WithMany(p => p.Compatibilidades)
                .HasForeignKey(cp => cp.PecaId);

            modelBuilder.Entity<CompatibilidadePeca>()
                .HasOne(pc => pc.PecaCompativel)
                .WithMany()
                .HasForeignKey(pc => pc.PecaCompativelId);
        }

        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<PecaVendida> PecaVendida { get; set; }
        public DbSet<PecasCompradas> PecasCompradas { get; set; }
        public DbSet<ExemplarPeca> ExemplarPeca { get; set; }
        public DbSet<CompraPeca> CompraPeca { get; set; }
        
    }
}
