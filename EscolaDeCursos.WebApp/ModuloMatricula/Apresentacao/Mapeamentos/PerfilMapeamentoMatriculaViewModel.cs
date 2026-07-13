using AutoMapper;

using EscolaDeCursos.Aplicacao.ModuloMatricula.DTOs;
using EscolaDeCursos.WebApp.ModuloMatricula.Apresentacao.Models;

namespace EscolaDeCursos.WebApp.ModuloMatricula.Apresentacao.Mapeamentos;

public class PerfilMapeamentoMatriculaViewModel : Profile
{
    public PerfilMapeamentoMatriculaViewModel()
    {
        CreateMap<CadastrarMatriculaViewModel, CadastrarMatriculaDto>();

        CreateMap<EditarMatriculaViewModel, EditarMatriculaDto>();

        CreateMap<VisualizarMatriculaDto, EditarMatriculaViewModel>()
            .ForMember(
                dest => dest.Situacao,
                opt => opt.MapFrom(src =>
                    Enum.Parse<EscolaDeCursos.Dominio.Enumeradores.SituacaoMatricula>(src.Situacao)));

        CreateMap<VisualizarMatriculaDto, ExcluirMatriculaViewModel>();

        CreateMap<ListarMatriculaDto, ListarMatriculaViewModel>();
    }
}
