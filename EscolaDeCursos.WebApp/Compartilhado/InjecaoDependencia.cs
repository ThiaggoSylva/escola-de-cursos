using EscolaDeCursos.WebApp.Compartilhado.Mapping;
using AutoMapper;

namespace EscolaDeCursos.WebApp.Compartilhado;

public static class InjecaoDependencia
{
    public static void AddPresentationConfig(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddControllersWithViews().AddRazorOptions(options =>
        {
            // Reseta a configuração padrão do MVC
            options.ViewLocationFormats.Clear();

            options.ViewLocationFormats.Add(
                "/Modulo{1}/Apresentacao/Views/{0}.cshtml"
            );

            options.ViewLocationFormats.Add(
                "/Compartilhado/Apresentacao/Views/Home/{0}.cshtml"
            );

            options.ViewLocationFormats.Add(
                "/Compartilhado/Apresentacao/Views/Shared/{0}.cshtml"
            );
        });

        services.AddAutoMapper(mapperConfig =>
        {
            AutoMapperOptions autoMapperOptions = configuration
                .GetSection(AutoMapperOptions.SectionName)
                .Get<AutoMapperOptions>() ?? new AutoMapperOptions();

            string? licenseKey = autoMapperOptions.LicenseKey;

            if (!string.IsNullOrWhiteSpace(licenseKey))
                mapperConfig.LicenseKey = licenseKey;

            mapperConfig.AddMaps(typeof(Program));
        });
    }
}

