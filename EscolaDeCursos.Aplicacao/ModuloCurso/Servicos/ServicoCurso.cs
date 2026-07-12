using AutoMapper;
using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Aplicacao.ModuloCurso.DTOs;
using EscolaDeCursos.Dominio;
using FluentResults;

namespace EscolaDeCursos.Aplicacao.ModuloCurso.Servicos;

public class ServicoCurso : ServicoBase<Curso>
{
    private readonly IRepositorioCurso repositorioCurso;
    private readonly IRepositorioCategoria repositorioCategoria;
    private readonly IMapper mapper;

    public ServicoCurso(
        IRepositorioCurso repositorioCurso,
        IRepositorioCategoria repositorioCategoria,
        IMapper mapper)
    {
        this.repositorioCurso = repositorioCurso;
        this.repositorioCategoria = repositorioCategoria;
        this.mapper = mapper;
    }

    public Result<Guid> Cadastrar(
        CadastrarCursoDto dto)
    {
        Curso curso =
            mapper.Map<Curso>(dto);

        List<string> erros =
            curso.Validar();

        if (repositorioCategoria
            .SelecionarPorId(dto.CategoriaId) is null)
        {
            erros.Add(
                "A categoria informada não existe."
            );
        }

        if (repositorioCurso.ExisteCursoComTitulo(
            curso.Titulo,
            curso.CategoriaId))
        {
            erros.Add(
                "Já existe um curso com este título nesta categoria."
            );
        }

        if (erros.Any())
            return Result.Fail(erros);

        repositorioCurso.Cadastrar(curso);

        return Result.Ok(curso.Id);
    }

    public Result Editar(
        Guid id,
        EditarCursoDto dto)
    {
        Curso curso =
            mapper.Map<Curso>(dto);

        curso.Id = id;

        List<string> erros =
            curso.Validar();

        if (repositorioCategoria
            .SelecionarPorId(dto.CategoriaId) is null)
        {
            erros.Add(
                "A categoria informada não existe."
            );
        }

        if (repositorioCurso.ExisteCursoComTitulo(
            curso.Titulo,
            curso.CategoriaId,
            curso.Id))
        {
            erros.Add(
                "Já existe um curso com este título nesta categoria."
            );
        }

        if (erros.Any())
            return Result.Fail(erros);

        bool conseguiuEditar =
            repositorioCurso.Editar(
                curso.Id,
                curso);

        if (!conseguiuEditar)
            return Result.Fail(
                "Curso não encontrado."
            );

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        if (repositorioCurso
            .PossuiTurmasVinculadas(id))
        {
            return Result.Fail(
                "Não é possível excluir um curso que possui turmas vinculadas."
            );
        }

        bool conseguiuExcluir =
            repositorioCurso.Excluir(id);

        if (!conseguiuExcluir)
        {
            return Result.Fail(
                "Curso não encontrado."
            );
        }

        return Result.Ok();
    }

    public Result<List<ListarCursoDto>>
        SelecionarTodos()
    {
        List<Curso> cursos =
            repositorioCurso.SelecionarTodos();

        List<ListarCursoDto> registros =
            mapper.Map<List<ListarCursoDto>>(cursos);

        return Result.Ok(registros);
    }

    public Result<VisualizarCursoDto>
        SelecionarPorId(Guid id)
    {
        Curso? curso =
            repositorioCurso.SelecionarPorId(id);

        if (curso is null)
        {
            return Result.Fail(
                "Curso não encontrado."
            );
        }

        VisualizarCursoDto dto =
            mapper.Map<VisualizarCursoDto>(curso);

        return Result.Ok(dto);
    }

    public Result<List<ListarCursoDto>>
        SelecionarPorCategoria(Guid categoriaId)
    {
        List<Curso> cursos =
            repositorioCurso.Filtrar(
                x => x.CategoriaId == categoriaId);

        List<ListarCursoDto> registros =
            mapper.Map<List<ListarCursoDto>>(cursos);

        return Result.Ok(registros);
    }
}
