using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteDirectData.Models;
using TesteDirectData2.Models;

namespace TesteDirectData2.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {

        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(p => p.ID);
            builder.Property(p => p.User)
                .HasColumnType("varchar(30)")
                .IsRequired();
            builder.Property(p => p.Senha)
                .HasColumnType("varchar(30)")
                .IsRequired();
        }
    }
}
