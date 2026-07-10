using EscolaDeCursos.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaDeCursos.Infra.Mapeamentos;

public class MapeadorCursoOrm
    : IEntityTypeConfiguration<Curso>
{
    public void Configure(EntityTypeBuilder<Curso> builder)
    {
        builder.ToTable("TB_CURSO");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Titulo)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(x => x.Descricao)
            .HasColumnType("varchar(500)")
            .IsRequired();

        builder.Property(x => x.CargaHoraria)
            .IsRequired();

        builder.Property(x => x.Nivel)
            .IsRequired();

        builder.HasOne(x => x.Categoria)
            .WithMany(x => x.Cursos)
            .HasForeignKey(x => x.CategoriaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new
        {
            x.Titulo,
            x.CategoriaId
        }).IsUnique();
    }
}
