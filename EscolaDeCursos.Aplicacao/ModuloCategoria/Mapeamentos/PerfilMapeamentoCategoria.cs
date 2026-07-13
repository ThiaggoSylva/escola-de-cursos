using AutoMapper;

using EscolaDeCursos.Dominio;
using EscolaDeCursos.Aplicacao.ModuloCategoria.DTOs;

namespace EscolaDeCursos.Aplicacao.ModuloCategoria;

public class PerfilMapeamentoCategoria : Profile
{
    public PerfilMapeamentoCategoria()
    {
        Console.WriteLine("PerfilMapeamentoCategoria carregado");

        CreateMap<CadastrarCategoriaDto, Categoria>()
            .ConstructUsing(dto =>
                new Categoria(dto.Titulo));

        CreateMap<EditarCategoriaDto, Categoria>()
            .ConstructUsing(dto =>
                new Categoria(dto.Titulo));

        CreateMap<Categoria, ListarCategoriaDto>();

        CreateMap<Categoria, VisualizarCategoriaDto>();
    }
}
