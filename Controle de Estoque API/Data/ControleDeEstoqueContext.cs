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
    }
}
