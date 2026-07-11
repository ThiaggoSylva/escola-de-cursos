using AutoMapper;
using EscolaDeCursos.Aplicacao.ModuloCategoria.DTOs;
using EscolaDeCursos.Dominio;

namespace EscolaDeCursos.Aplicacao.ModuloCategoria.Mapeamentos;

public class PerfilMapeamentoCategoria : Profile
{
    public PerfilMapeamentoCategoria()
    {
        CreateMap<CadastrarCategoriaDto, Categoria>();

        CreateMap<EditarCategoriaDto, Categoria>();

        CreateMap<Categoria, ListarCategoriaDto>();

        CreateMap<Categoria, VisualizarCategoriaDto>();
    }
}
