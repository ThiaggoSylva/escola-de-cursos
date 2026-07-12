using AutoMapper;
using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Aplicacao.ModuloCategoria.DTOs;
using EscolaDeCursos.Dominio;
using FluentResults;

namespace EscolaDeCursos.Aplicacao.ModuloCategoria.Servicos;

public class ServicoCategoria : ServicoBase<Categoria>
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

    public Result<Guid> Cadastrar(
        CadastrarCategoriaDto dto)
    {
        Categoria categoria =
            mapper.Map<Categoria>(dto);

        List<string> erros =
            categoria.Validar();

        if (repositorioCategoria.ExisteCategoriaComTitulo(categoria.Titulo))
        {
            erros.Add(
                "Já existe uma categoria cadastrada com este título."
            );
        }

        if (erros.Any())
            return Result.Fail(erros);

        repositorioCategoria.Cadastrar(categoria);

        return Result.Ok(categoria.Id);
    }

    public Result Editar(
        Guid id,
        EditarCategoriaDto dto)
    {
        Categoria categoria =
            mapper.Map<Categoria>(dto);

        categoria.Id = id;

        List<string> erros =
            categoria.Validar();

        if (repositorioCategoria.ExisteCategoriaComTitulo(
                categoria.Titulo,
                categoria.Id))
        {
            erros.Add(
                "Já existe uma categoria cadastrada com este título."
            );
        }

        if (erros.Any())
            return Result.Fail(erros);

        bool conseguiuEditar =
            repositorioCategoria.Editar(
                categoria.Id,
                categoria);

        if (!conseguiuEditar)
        {
            return Result.Fail(
                "Categoria não encontrada."
            );
        }

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        if (repositorioCategoria.PossuiCursosVinculados(id))
        {
            return Result.Fail(
                "Não é possível excluir uma categoria que possui cursos vinculados."
            );
        }

        bool conseguiuExcluir =
            repositorioCategoria.Excluir(id);

        if (!conseguiuExcluir)
        {
            return Result.Fail(
                "Categoria não encontrada."
            );
        }

        return Result.Ok();
    }

    public Result<List<ListarCategoriaDto>>
        SelecionarTodos()
    {
        List<Categoria> categorias =
            repositorioCategoria.SelecionarTodos();

        List<ListarCategoriaDto> registros =
            mapper.Map<List<ListarCategoriaDto>>(
                categorias);

        return Result.Ok(registros);
    }

    public Result<VisualizarCategoriaDto>
        SelecionarPorId(Guid id)
    {
        Categoria? categoria =
            repositorioCategoria
                .SelecionarPorId(id);

        if (categoria is null)
        {
            return Result.Fail(
                "Categoria não encontrada."
            );
        }

        VisualizarCategoriaDto dto =
            mapper.Map<VisualizarCategoriaDto>(
                categoria);

        return Result.Ok(dto);
    }
}
