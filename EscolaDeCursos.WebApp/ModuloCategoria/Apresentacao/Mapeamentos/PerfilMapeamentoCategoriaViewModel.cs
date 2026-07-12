using AutoMapper;
using EscolaDeCursos.Aplicacao.ModuloCategoria.DTOs;
using EscolaDeCursos.ModuloCategoria.Apresentacao.Models;

namespace EscolaDeCursos.ModuloCategoria.Apresentacao.Mapeamentos;

public class PerfilMapeamentoCategoriaViewModel : Profile
{
    public PerfilMapeamentoCategoriaViewModel()
    {
        CreateMap<CadastrarCategoriaViewModel,
            CadastrarCategoriaDto>();

        CreateMap<EditarCategoriaViewModel,
            EditarCategoriaDto>();

        CreateMap<VisualizarCategoriaDto,
            EditarCategoriaViewModel>();

        CreateMap<VisualizarCategoriaDto,
            ExcluirCategoriaViewModel>();

        CreateMap<ListarCategoriaDto,
            ListarCategoriaViewModel>();
    }
}
