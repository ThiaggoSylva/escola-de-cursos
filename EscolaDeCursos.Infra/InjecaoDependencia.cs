using EscolaDeCursos.Infra.Compartilhado.Logging;
using EscolaDeCursos.Infra.Compartilhado.Orm;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using EscolaDeCursos.Dominio;
using EscolaDeCursos.Infra.Repositorios;

namespace EscolaDeCursos.Infra;

public static class InjecaoDependencia
{
    public static void AddInfraRepositories(
        this IServiceCollection services,
        IConfiguration configuration,
        ILoggingBuilder logging
    )
    {
        // Injeta logs do Serilog
        Log.Logger = SerilogFactory.Create(configuration);

        logging.ClearProviders();

        services.AddSerilog(Log.Logger);

        // Injeta o DbContext do EF
        services.AddDbContext<EscolaDeCursosDbContext>(options =>
        {
            string? connectionString = configuration.GetConnectionString("SqlServerEF");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    $"A connection string \"SqlServerEF\" não foi encontrada."
                );
            }

            options.UseSqlServer(connectionString, opt =>
            {
                opt.EnableRetryOnFailure(3);
            });
        });

            services.AddScoped<IRepositorioCategoria, RepositorioCategoriaOrm>();
            services.AddScoped<IRepositorioCurso, RepositorioCursoOrm>();
            services.AddScoped<IRepositorioModulo, RepositorioModuloOrm>();
            services.AddScoped<IRepositorioInstrutor, RepositorioInstrutorOrm>();
            services.AddScoped<IRepositorioAluno, RepositorioAlunoOrm>();
            services.AddScoped<IRepositorioTurma, RepositorioTurmaOrm>();
            services.AddScoped<IRepositorioMatricula, RepositorioMatriculaOrm>();
    }
}
