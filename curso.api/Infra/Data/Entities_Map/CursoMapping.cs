using curso.api.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace curso.api.Infra.Data.Entities_Map
{
    public class CursoMapping : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.ToTable("TB_CURSO");
            builder.HasKey(k => k.Codigo);
            builder.Property(k => k.Codigo).ValueGeneratedOnAdd();
            builder.Property(k => k.Nome);
            builder.Property(k => k.Descricao);
            builder.Property(k => k.CodigoUsuario);

        }
    }
}
