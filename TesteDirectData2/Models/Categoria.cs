namespace TesteDirectData.Models
{
    public class Categoria
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        //public virtual ICollection<Produto> Produtos { get; set; }
        public Categoria()
        {
            Nome = "";
        }

        public Categoria(int id, string nome) : this()
        {
            this.ID = id;
            this.Nome = nome;
        }
    }
}
