using Microsoft.EntityFrameworkCore;
using TesteDirectData.Mapping;
using TesteDirectData.Models;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
using TesteDirectData2.Mapping;
using TesteDirectData2.Models;

namespace TesteDirectData.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //faz mapeamento com bd
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new UnidadeMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());

        }

        //cria link com a entidades
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Unidade> Unidades { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
