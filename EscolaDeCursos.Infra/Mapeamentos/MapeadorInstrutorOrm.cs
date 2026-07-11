using EscolaDeCursos.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaDeCursos.Infra.Mapeamentos;

public class MapeadorInstrutorOrm
    : IEntityTypeConfiguration<Instrutor>
{
    public void Configure(EntityTypeBuilder<Instrutor> builder)
    {
        builder.ToTable("TB_INSTRUTOR");

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

        builder.Property(x => x.Especialidade)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.HasIndex(x => x.Email)
            .IsUnique();

        builder.HasIndex(x => x.Telefone)
            .IsUnique();
    }
}
