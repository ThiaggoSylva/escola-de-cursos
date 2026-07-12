using AutoMapper;
using EscolaDeCursos.Aplicacao.ModuloModulo.DTOs;
using EscolaDeCursos.Dominio;

namespace EscolaDeCursos.Aplicacao.ModuloModulo.Mapeamentos;

public class PerfilMapeamentoModulo : Profile
{
    public PerfilMapeamentoModulo()
    {
        CreateMap<CadastrarModuloDto, Modulo>();

        CreateMap<EditarModuloDto, Modulo>();

        CreateMap<Modulo, ListarModuloDto>()
            .ForMember(
                dest => dest.Curso,
                opt => opt.MapFrom(src => src.Curso!.Titulo)
            );

        CreateMap<Modulo, VisualizarModuloDto>()
            .ForMember(
                dest => dest.Curso,
                opt => opt.MapFrom(src => src.Curso!.Titulo)
            );
    }
}
