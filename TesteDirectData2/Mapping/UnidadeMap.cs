using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteDirectData.Models;

namespace TesteDirectData.Mapping
{
    public class UnidadeMap : IEntityTypeConfiguration<Unidade>
    {
        public void Configure(EntityTypeBuilder<Unidade> builder)
        {
            builder.ToTable("Unidade");
            builder.HasKey(p => p.ID);
            builder.Property(p => p.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(p => p.Localidade)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(p => p.Contato)
                .HasColumnType("varchar(15)")
                .IsRequired();
        }
    }
}
