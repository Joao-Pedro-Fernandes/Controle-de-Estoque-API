namespace Controle_de_Estoque_API.Contract.Pecas
{
    public class PostCreatePecaRequest
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Localizacao { get; set; }
        public string Grau_Importancia { get; set; }
        public int Quantidade_Estoque { get; set; }
    }
}
