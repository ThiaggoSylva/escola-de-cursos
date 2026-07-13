using EscolaDeCursos.Aplicacao;
using EscolaDeCursos.Infra;
using EscolaDeCursos.WebApp.Compartilhado;
using EscolaDeCursos.WebApp.Compartilhado.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Configuração do container de injeção de dependência

builder.Services.AddInfraRepositories(builder.Configuration, builder.Logging);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddPresentationConfig(builder.Configuration);

builder.Services.AddAutoMapper((serviceProvider, mapperConfig) =>
{
    AutoMapperOptions options = builder.Configuration
        .GetSection(AutoMapperOptions.SectionName)
        .Get<AutoMapperOptions>() ?? new AutoMapperOptions();

    if (!string.IsNullOrWhiteSpace(options.LicenseKey))
        mapperConfig.LicenseKey = options.LicenseKey;
},
AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Middlewares de roteamento
app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();

// Execução do Servidor
app.Run();
