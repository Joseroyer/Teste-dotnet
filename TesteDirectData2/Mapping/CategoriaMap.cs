using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteDirectData.Models;

namespace TesteDirectData.Mapping
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {

        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria");
            builder.HasKey(p => p.ID);
            builder.Property(p => p.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            //builder.HasData(
              //  new Categoria(10, "Software"));
        }
    }
}
