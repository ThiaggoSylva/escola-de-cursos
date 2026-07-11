using EscolaDeCursos.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaDeCursos.Infra.Mapeamentos;

public class MapeadorAlunoOrm
    : IEntityTypeConfiguration<Aluno>
{
    public void Configure(EntityTypeBuilder<Aluno> builder)
    {
        builder.ToTable("TB_ALUNO");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Nome)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(x => x.Email)
            .HasColumnType("varchar(200)")
            .IsRequired();

        builder.Property(x => x.Telefone)
            .HasColumnType("varchar(20)")
            .IsRequired();

        builder.Property(x => x.CPF)
            .HasColumnType("varchar(14)")
            .IsRequired();

        builder.HasIndex(x => x.CPF)
            .IsUnique();

        builder.HasIndex(x => x.Email)
            .IsUnique();

        builder.HasIndex(x => x.Telefone)
            .IsUnique();
    }
}
