using AutoMapper;

using EscolaDeCursos.Aplicacao.ModuloInstrutor.DTOs;
using EscolaDeCursos.WebApp.ModuloInstrutor.Apresentacao.Models;

namespace EscolaDeCursos.WebApp.ModuloInstrutor.Apresentacao.Mapeamentos;

public class PerfilMapeamentoInstrutorViewModel : Profile
{
    public PerfilMapeamentoInstrutorViewModel()
    {
        CreateMap<CadastrarInstrutorViewModel, CadastrarInstrutorDto>();

        CreateMap<EditarInstrutorViewModel, EditarInstrutorDto>();

        CreateMap<VisualizarInstrutorDto, EditarInstrutorViewModel>();

        CreateMap<VisualizarInstrutorDto, ExcluirInstrutorViewModel>();

        CreateMap<ListarInstrutorDto, ListarInstrutorViewModel>();
    }
}
