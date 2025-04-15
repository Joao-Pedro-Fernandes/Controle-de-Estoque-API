using System.ComponentModel.DataAnnotations.Schema;

namespace Controle_de_Estoque_API.Data.Models
{
    public class CompatibilidadePeca
    {
        public int Id { get; set; }
        public int PecaId { get; set; }
        public Peca Peca { get; set; }
        public int PecaCompativelId {  get; set; }
        public Peca PecaCompativel { get; set; }

    }
}
