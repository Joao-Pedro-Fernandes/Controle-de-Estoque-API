using System.ComponentModel.DataAnnotations.Schema;

namespace Controle_de_Estoque_API.Data.Models
{
    public class CompraPeca
    {
        public int Id { get; set; }
        public DateTime Data {  get; set; }
        public string CodigoPedido { get; set; }

        [ForeignKey("Vendedor")]
        public int IdVendedor { get; set; }
        public Vendedor Vendedor { get; set; }

        List<PecasCompradas> PecasCompradas { get; set; }
    }
}
