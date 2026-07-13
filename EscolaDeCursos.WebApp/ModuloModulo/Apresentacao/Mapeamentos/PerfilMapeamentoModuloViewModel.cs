using AutoMapper;

using EscolaDeCursos.Aplicacao.ModuloModulo.DTOs;
using EscolaDeCursos.WebApp.ModuloModulo.Apresentacao.Models;

namespace EscolaDeCursos.WebApp.ModuloModulo.Apresentacao.Mapeamentos;

public class PerfilMapeamentoModuloViewModel : Profile
{
    public PerfilMapeamentoModuloViewModel()
    {
        CreateMap<CadastrarModuloViewModel, CadastrarModuloDto>();

        CreateMap<EditarModuloViewModel, EditarModuloDto>();

        CreateMap<VisualizarModuloDto, EditarModuloViewModel>();

        CreateMap<VisualizarModuloDto, ExcluirModuloViewModel>();

        CreateMap<ListarModuloDto, ListarModuloViewModel>();
    }
}
