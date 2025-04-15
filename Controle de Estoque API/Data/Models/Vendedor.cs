namespace Controle_de_Estoque_API.Data.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<CompraPeca> compraPecaList { get; set; } = new List<CompraPeca>();
    }
}
