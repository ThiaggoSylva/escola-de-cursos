using AutoMapper;
using EscolaDeCursos.Aplicacao.ModuloCurso.DTOs;
using EscolaDeCursos.Dominio;

namespace EscolaDeCursos.Aplicacao.ModuloCurso.Mapeamentos;

public class PerfilMapeamentoCurso : Profile
{
    public PerfilMapeamentoCurso()
    {
        CreateMap<CadastrarCursoDto, Curso>();

        CreateMap<EditarCursoDto, Curso>();

        CreateMap<Curso, ListarCursoDto>()
            .ForMember(
                dest => dest.Categoria,
                opt => opt.MapFrom(src => src.Categoria!.Titulo)
            )
            .ForMember(
                dest => dest.Nivel,
                opt => opt.MapFrom(src => src.Nivel.ToString())
            );

        CreateMap<Curso, VisualizarCursoDto>()
            .ForMember(
                dest => dest.Categoria,
                opt => opt.MapFrom(src => src.Categoria!.Titulo)
            )
            .ForMember(
                dest => dest.Nivel,
                opt => opt.MapFrom(src => src.Nivel.ToString())
            );
    }
}
