using System.ComponentModel.DataAnnotations.Schema;

namespace Controle_de_Estoque_API.Data.Models
{
    public class ExemplarPeca
    {
        public int Id { get; set; }
        public double ValorPago { get; set; }
        public bool EmEstoque { get; set; }
        public string CodigoVendedor { get; set;}

        [ForeignKey("Peca")]
        public int PecaId { get; set; }

        public Peca Peca { get; set; }

        public List<PecasCompradas> PecasCompradas { get; set; } = new List<PecasCompradas>();
        public List<PecaVendida> PecasVendidas { get; set; } = new List<PecaVendida>();

    }
}
