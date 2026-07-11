using AutoMapper;
using EscolaDeCursos.Aplicacao.ModuloCategoria.DTOs;
using EscolaDeCursos.Dominio;

namespace EscolaDeCursos.Aplicacao.ModuloCategoria.Servicos;

public class ServicoCategoria
{
    private readonly IRepositorioCategoria repositorioCategoria;
    private readonly IMapper mapper;

    public ServicoCategoria(
        IRepositorioCategoria repositorioCategoria,
        IMapper mapper)
    {
        this.repositorioCategoria = repositorioCategoria;
        this.mapper = mapper;
    }

    public List<string> Cadastrar(
        CadastrarCategoriaDto dto)
    {
        Categoria categoria =
            mapper.Map<Categoria>(dto);

        List<string> erros =
            categoria.Validar();

        if (repositorioCategoria.SelecionarTodos()
            .Any(c => c.Titulo.Equals(categoria.Titulo, StringComparison.OrdinalIgnoreCase)))
            erros.Add("Já existe uma categoria com este título.");

        if (erros.Any())
            return erros;

        repositorioCategoria.Cadastrar(categoria);

        return [];
    }

    public List<ListarCategoriaDto> SelecionarTodos()
    {
        List<Categoria> categorias =
            repositorioCategoria.SelecionarTodos();

        return mapper.Map<List<ListarCategoriaDto>>(categorias);
    }

    public VisualizarCategoriaDto? SelecionarPorId(Guid id)
    {
        Categoria? categoria =
            repositorioCategoria.SelecionarPorId(id);

        if (categoria is null)
            return null;

        return mapper.Map<VisualizarCategoriaDto>(categoria);
    }

    public List<string> Editar(
        EditarCategoriaDto dto)
    {
        Categoria categoria =
            mapper.Map<Categoria>(dto);

        List<string> erros =
            categoria.Validar();

        if (repositorioCategoria.SelecionarTodos()
            .Any(c => c.Titulo.Equals(categoria.Titulo, StringComparison.OrdinalIgnoreCase) && c.Id != categoria.Id))
        {
            erros.Add("Já existe uma categoria com este título.");
        }

        if (erros.Any())
            return erros;

        repositorioCategoria.Editar(
            categoria.Id,
            categoria);

        return [];
    }

    public List<string> Excluir(Guid id)
    {
        List<string> erros = [];

        if (repositorioCategoria.PossuiCursosVinculados(id))
        {
            erros.Add(
                "Não é possível excluir uma categoria com cursos vinculados."
            );

            return erros;
        }

        repositorioCategoria.Excluir(id);

        return erros;
    }
}