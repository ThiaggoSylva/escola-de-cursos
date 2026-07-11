using EscolaDeCursos.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaDeCursos.Infra.Mapeamentos;

public class MapeadorTurmaOrm
    : IEntityTypeConfiguration<Turma>
{
    public void Configure(EntityTypeBuilder<Turma> builder)
    {
        builder.ToTable("TB_TURMA");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Nome)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(x => x.CapacidadeMaxima)
            .IsRequired();

        builder.Property(x => x.DataInicio)
            .IsRequired();

        builder.Property(x => x.DataTermino)
            .IsRequired();

        builder.HasOne(x => x.Curso)
            .WithMany(x => x.Turmas)
            .HasForeignKey(x => x.CursoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Instrutor)
            .WithMany(x => x.Turmas)
            .HasForeignKey(x => x.InstrutorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
