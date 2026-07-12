using EscolaDeCursos.Aplicacao.ModuloCategoria.Servicos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EscolaDeCursos.Aplicacao.ModuloCurso.Servicos;
using EscolaDeCursos.Aplicacao.ModuloModulo.Servicos;
using EscolaDeCursos.Aplicacao.ModuloInstrutor.Servicos;
using EscolaDeCursos.Aplicacao.ModuloAluno.Servicos;
using EscolaDeCursos.Aplicacao.ModuloTurma.Servicos;
using EscolaDeCursos.Aplicacao.ModuloMatricula.Servicos;

namespace EscolaDeCursos.Aplicacao;

public static class InjecaoDependencia
{
    public static void AddApplicationServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddScoped<ServicoCategoria>();
        services.AddScoped<ServicoCurso>();
        services.AddScoped<ServicoModulo>();
        services.AddScoped<ServicoInstrutor>();
        services.AddScoped<ServicoAluno>();
        services.AddScoped<ServicoTurma>();
        services.AddScoped<ServicoMatricula>();
    }
}
