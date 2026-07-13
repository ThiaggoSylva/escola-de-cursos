using AutoMapper;

using EscolaDeCursos.Aplicacao.ModuloAluno.DTOs;
using EscolaDeCursos.WebApp.ModuloAluno.Apresentacao.Models;

namespace EscolaDeCursos.WebApp.ModuloAluno.Apresentacao.Mapeamentos;

public class PerfilMapeamentoAlunoViewModel : Profile
{
    public PerfilMapeamentoAlunoViewModel()
    {
        CreateMap<CadastrarAlunoViewModel, CadastrarAlunoDto>();

        CreateMap<EditarAlunoViewModel, EditarAlunoDto>();

        CreateMap<VisualizarAlunoDto, EditarAlunoViewModel>();

        CreateMap<VisualizarAlunoDto, ExcluirAlunoViewModel>();

        CreateMap<ListarAlunoDto, ListarAlunoViewModel>();
    }
}
