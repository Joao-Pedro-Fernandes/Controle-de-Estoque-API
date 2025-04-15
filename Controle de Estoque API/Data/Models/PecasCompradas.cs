using System.ComponentModel.DataAnnotations.Schema;

namespace Controle_de_Estoque_API.Data.Models
{
    public class PecasCompradas
    {
        public int Id { get; set; }
        public string CodigoPecaVendedor { get; set; }
        public double Valor {  get; set; }

        [ForeignKey("CompraPeca")]
        public int IdCompraPecas { get; set; }
        public CompraPeca CompraPeca { get; set; }

        [ForeignKey("ExemplarPeca")]
        public int IdExemplarPeca { get; set; }
        public ExemplarPeca ExemplarPeca { get; set;}
    }
}
