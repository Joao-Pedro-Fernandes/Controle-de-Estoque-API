using System.ComponentModel.DataAnnotations.Schema;

namespace Controle_de_Estoque_API.Data.Models
{
    public class PecaVendida
    {
        public int Id { get; set; }      
        public DateTime DataVenda { get; set; }
        public string NomeCliente { get; set; }
        public string CodigoOS { get; set; }
        public string Observacao { get; set; }

        [ForeignKey("ExemplarPeca")]
        public int ExemplarPecaId { get; set; }
        public ExemplarPeca ExemplarPeca { get; set; }
    }
}
