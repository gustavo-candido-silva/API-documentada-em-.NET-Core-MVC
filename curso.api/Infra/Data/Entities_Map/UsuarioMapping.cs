using curso.api.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace curso.api.Infra.Data.Entities_Map
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("TB_USUARIO");
            builder.HasKey(k => k.Codigo);
            builder.Property(k => k.Codigo).ValueGeneratedOnAdd();
            builder.Property(k => k.Login);
            builder.Property(k => k.Email);
            builder.Property(k => k.Senha);
        }
    }
}
