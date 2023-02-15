using System.Reflection.Metadata.Ecma335;

namespace TesteDirectData.Models
{
    public class Produto
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        public decimal PrecoVenda { get; set; }
        public int Estoque { get; set; }

        public int Ativo { get; set; }

        public int UnidadeID { get; set; }
        public Unidade? Unidade { get; set; }
        public int CategoriaID { get; set; }
        public Categoria? Categorias { get; set; }

    }
}
