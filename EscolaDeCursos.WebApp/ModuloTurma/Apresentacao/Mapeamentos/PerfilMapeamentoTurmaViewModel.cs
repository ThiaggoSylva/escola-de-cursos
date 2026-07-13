using AutoMapper;

using EscolaDeCursos.Aplicacao.ModuloTurma.DTOs;
using EscolaDeCursos.WebApp.ModuloTurma.Apresentacao.Models;

namespace EscolaDeCursos.WebApp.ModuloTurma.Apresentacao.Mapeamentos;

public class PerfilMapeamentoTurmaViewModel : Profile
{
    public PerfilMapeamentoTurmaViewModel()
    {
        CreateMap<CadastrarTurmaViewModel, CadastrarTurmaDto>();

        CreateMap<EditarTurmaViewModel, EditarTurmaDto>();

        CreateMap<VisualizarTurmaDto, EditarTurmaViewModel>();

        CreateMap<VisualizarTurmaDto, ExcluirTurmaViewModel>();

        CreateMap<ListarTurmaDto, ListarTurmaViewModel>();
    }
}
