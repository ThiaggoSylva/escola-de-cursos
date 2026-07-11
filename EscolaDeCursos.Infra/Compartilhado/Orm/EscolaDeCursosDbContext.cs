using System.Reflection;
using Microsoft.EntityFrameworkCore;
using EscolaDeCursos.Dominio;

namespace EscolaDeCursos.Infra.Compartilhado.Orm;

public sealed class EscolaDeCursosDbContext(
    DbContextOptions<EscolaDeCursosDbContext> options) : DbContext(options)
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Curso> Cursos { get; set; }
    public DbSet<Modulo> Modulos { get; set; }
    public DbSet<Instrutor> Instrutores { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Assembly assembly = typeof(EscolaDeCursosDbContext).Assembly;

        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
    }
}
