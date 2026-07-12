using AutoMapper;
using EscolaDeCursos.Aplicacao.ModuloTurma.DTOs;
using EscolaDeCursos.Dominio;

namespace EscolaDeCursos.Aplicacao.ModuloTurma.Mapeamentos;

public class PerfilMapeamentoTurma : Profile
{
    public PerfilMapeamentoTurma()
    {
        CreateMap<CadastrarTurmaDto, Turma>();

        CreateMap<EditarTurmaDto, Turma>();

        CreateMap<Turma, ListarTurmaDto>()
            .ForMember(
                dest => dest.Curso,
                opt => opt.MapFrom(src => src.Curso!.Titulo)
            )
            .ForMember(
                dest => dest.Instrutor,
                opt => opt.MapFrom(src => src.Instrutor!.Nome)
            );

        CreateMap<Turma, VisualizarTurmaDto>()
            .ForMember(
                dest => dest.Curso,
                opt => opt.MapFrom(src => src.Curso!.Titulo)
            )
            .ForMember(
                dest => dest.Instrutor,
                opt => opt.MapFrom(src => src.Instrutor!.Nome)
            );
    }
}
