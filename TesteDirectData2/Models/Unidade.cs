namespace TesteDirectData.Models
{
    public class Unidade
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Localidade { get; set; }
        public string Contato { get; set; }
        //public virtual ICollection<Produto> Produtos { get; set; }
        public Unidade()
        {
            Nome = "";
            Localidade = "";
            Contato = "";
        }

        public Unidade(string nome, string localidade, string contato)
        {
            Nome = nome;
            Localidade = localidade;
            Contato = contato;
        }

        public Unidade(int iD, string nome, string localidade, string contato)
        {
            ID = iD;
            Nome = nome;
            Localidade = localidade;
            Contato = contato;
        }
    }
}
