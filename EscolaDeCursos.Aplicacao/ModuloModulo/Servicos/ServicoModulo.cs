using AutoMapper;
using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Aplicacao.ModuloModulo.DTOs;
using EscolaDeCursos.Dominio;
using FluentResults;

namespace EscolaDeCursos.Aplicacao.ModuloModulo.Servicos;

public class ServicoModulo : ServicoBase<Modulo>
{
    private readonly IRepositorioModulo repositorioModulo;
    private readonly IRepositorioCurso repositorioCurso;
    private readonly IMapper mapper;

    public ServicoModulo(
        IRepositorioModulo repositorioModulo,
        IRepositorioCurso repositorioCurso,
        IMapper mapper)
    {
        this.repositorioModulo = repositorioModulo;
        this.repositorioCurso = repositorioCurso;
        this.mapper = mapper;
    }

    public Result<Guid> Cadastrar(
        CadastrarModuloDto dto)
    {
        Modulo modulo =
            mapper.Map<Modulo>(dto);

        List<string> erros =
            modulo.Validar();

        if (repositorioCurso
            .SelecionarPorId(dto.CursoId) is null)
        {
            erros.Add(
                "O curso informado não existe."
            );
        }

        if (repositorioModulo.ExisteOrdemNoCurso(
            dto.CursoId,
            dto.Ordem))
        {
            erros.Add(
                "Já existe um módulo com esta ordem neste curso."
            );
        }

        if (erros.Any())
            return Result.Fail(erros);

        repositorioModulo.Cadastrar(modulo);

        return Result.Ok(modulo.Id);
    }

    public Result Editar(
        Guid id,
        EditarModuloDto dto)
    {
        Modulo modulo =
            mapper.Map<Modulo>(dto);

        modulo.Id = id;

        List<string> erros =
            modulo.Validar();

        if (repositorioCurso
            .SelecionarPorId(dto.CursoId) is null)
        {
            erros.Add(
                "O curso informado não existe."
            );
        }

        if (repositorioModulo.ExisteOrdemNoCurso(
            dto.CursoId,
            dto.Ordem,
            modulo.Id))
        {
            erros.Add(
                "Já existe um módulo com esta ordem neste curso."
            );
        }

        if (erros.Any())
            return Result.Fail(erros);

        bool conseguiuEditar =
            repositorioModulo.Editar(
                modulo.Id,
                modulo);

        if (!conseguiuEditar)
        {
            return Result.Fail(
                "Módulo não encontrado."
            );
        }

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        bool conseguiuExcluir =
            repositorioModulo.Excluir(id);

        if (!conseguiuExcluir)
        {
            return Result.Fail(
                "Módulo não encontrado."
            );
        }

        return Result.Ok();
    }

    public Result<List<ListarModuloDto>>
        SelecionarTodos()
    {
        List<Modulo> modulos =
            repositorioModulo.SelecionarTodos();

        List<ListarModuloDto> registros =
            mapper.Map<List<ListarModuloDto>>(modulos);

        return Result.Ok(registros);
    }

    public Result<VisualizarModuloDto>
        SelecionarPorId(Guid id)
    {
        Modulo? modulo =
            repositorioModulo.SelecionarPorId(id);

        if (modulo is null)
        {
            return Result.Fail(
                "Módulo não encontrado."
            );
        }

        VisualizarModuloDto dto =
            mapper.Map<VisualizarModuloDto>(modulo);

        return Result.Ok(dto);
    }

    public Result<List<ListarModuloDto>>
        SelecionarPorCurso(Guid cursoId)
    {
        List<Modulo> modulos =
            repositorioModulo.Filtrar(
                x => x.CursoId == cursoId);

        List<ListarModuloDto> registros =
            mapper.Map<List<ListarModuloDto>>(modulos);

        return Result.Ok(registros);
    }
}
