using EscolaDeCursos.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaDeCursos.Infra.Mapeamentos;

public class MapeadorModuloOrm
    : IEntityTypeConfiguration<Modulo>
{
    public void Configure(EntityTypeBuilder<Modulo> builder)
    {
        builder.ToTable("TB_MODULO");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Titulo)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(x => x.Ordem)
            .IsRequired();

        builder.Property(x => x.DuracaoHoras)
            .IsRequired();

        builder.HasOne(x => x.Curso)
            .WithMany(x => x.Modulos)
            .HasForeignKey(x => x.CursoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => new
        {
            x.CursoId,
            x.Ordem
        }).IsUnique();
    }
}
