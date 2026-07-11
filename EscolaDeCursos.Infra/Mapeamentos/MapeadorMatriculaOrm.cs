using EscolaDeCursos.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaDeCursos.Infra.Mapeamentos;

public class MapeadorMatriculaOrm
    : IEntityTypeConfiguration<Matricula>
{
    public void Configure(EntityTypeBuilder<Matricula> builder)
    {
        builder.ToTable("TB_MATRICULA");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.DataMatricula)
            .IsRequired();

        builder.Property(x => x.Situacao)
            .IsRequired();

        builder.HasOne(x => x.Aluno)
            .WithMany(x => x.Matriculas)
            .HasForeignKey(x => x.AlunoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Turma)
            .WithMany(x => x.Matriculas)
            .HasForeignKey(x => x.TurmaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new
        {
            x.AlunoId,
            x.TurmaId
        }).IsUnique();
    }
}
