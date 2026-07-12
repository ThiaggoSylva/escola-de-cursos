using AutoMapper;
using EscolaDeCursos.Aplicacao.ModuloMatricula.DTOs;
using EscolaDeCursos.Dominio;

namespace EscolaDeCursos.Aplicacao.ModuloMatricula.Mapeamentos;

public class PerfilMapeamentoMatricula : Profile
{
    public PerfilMapeamentoMatricula()
    {
        CreateMap<CadastrarMatriculaDto, Matricula>();

        CreateMap<EditarMatriculaDto, Matricula>();

        CreateMap<Matricula, ListarMatriculaDto>()
            .ForMember(
                dest => dest.Aluno,
                opt => opt.MapFrom(src => src.Aluno!.Nome)
            )
            .ForMember(
                dest => dest.Turma,
                opt => opt.MapFrom(src => src.Turma!.Nome)
            )
            .ForMember(
                dest => dest.Situacao,
                opt => opt.MapFrom(src => src.Situacao.ToString())
            );

        CreateMap<Matricula, VisualizarMatriculaDto>()
            .ForMember(
                dest => dest.Aluno,
                opt => opt.MapFrom(src => src.Aluno!.Nome)
            )
            .ForMember(
                dest => dest.Turma,
                opt => opt.MapFrom(src => src.Turma!.Nome)
            )
            .ForMember(
                dest => dest.Situacao,
                opt => opt.MapFrom(src => src.Situacao.ToString())
            );
    }
}
