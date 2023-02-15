using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteDirectData.Models;

namespace TesteDirectData.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(p => p.ID);
            builder.Property(p => p.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(p => p.PrecoVenda)
                .HasColumnType("decimal(10,2)")
                .IsRequired();
            builder.Property(p => p.Estoque)
                .HasColumnType("Integer")
                .IsRequired();
            builder.Property(p => p.Ativo)
                .HasColumnType("Integer")
                .IsRequired();
            builder.HasOne(p => p.Unidade).WithMany().HasForeignKey(p => p.UnidadeID);
            builder.HasOne(p => p.Categorias).WithMany().HasForeignKey(p => p.CategoriaID);

        }
    }
}
