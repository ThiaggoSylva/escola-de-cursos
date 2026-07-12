using AutoMapper;
using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Aplicacao.ModuloTurma.DTOs;
using EscolaDeCursos.Dominio;
using FluentResults;

namespace EscolaDeCursos.Aplicacao.ModuloTurma.Servicos;

public class ServicoTurma : ServicoBase<Turma>
{
    private readonly IRepositorioTurma repositorioTurma;
    private readonly IRepositorioCurso repositorioCurso;
    private readonly IRepositorioInstrutor repositorioInstrutor;
    private readonly IMapper mapper;

    public ServicoTurma(
        IRepositorioTurma repositorioTurma,
        IRepositorioCurso repositorioCurso,
        IRepositorioInstrutor repositorioInstrutor,
        IMapper mapper)
    {
        this.repositorioTurma = repositorioTurma;
        this.repositorioCurso = repositorioCurso;
        this.repositorioInstrutor = repositorioInstrutor;
        this.mapper = mapper;
    }

    public Result<Guid> Cadastrar(
        CadastrarTurmaDto dto)
    {
        Turma turma = mapper.Map<Turma>(dto);

        List<string> erros = turma.Validar();

        if (repositorioCurso
            .SelecionarPorId(dto.CursoId) is null)
        {
            erros.Add("Curso não encontrado.");
        }

        if (repositorioInstrutor
            .SelecionarPorId(dto.InstrutorId) is null)
        {
            erros.Add("Instrutor não encontrado.");
        }

        if (erros.Any())
            return Result.Fail(erros);

        repositorioTurma.Cadastrar(turma);

        return Result.Ok(turma.Id);
    }

    public Result Editar(
        Guid id,
        EditarTurmaDto dto)
    {
        Turma turma =
            mapper.Map<Turma>(dto);

        turma.Id = id;

        List<string> erros =
            turma.Validar();

        if (repositorioCurso
            .SelecionarPorId(dto.CursoId) is null)
        {
            erros.Add("Curso não encontrado.");
        }

        if (repositorioInstrutor
            .SelecionarPorId(dto.InstrutorId) is null)
        {
            erros.Add("Instrutor não encontrado.");
        }

        if (erros.Any())
            return Result.Fail(erros);

        bool conseguiuEditar =
            repositorioTurma.Editar(
                turma.Id,
                turma);

        if (!conseguiuEditar)
            return Result.Fail(
                "Turma não encontrada."
            );

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        if (repositorioTurma
            .PossuiMatriculasVinculadas(id))
        {
            return Result.Fail(
                "Não é possível excluir uma turma com matrículas vinculadas."
            );
        }

        bool conseguiuExcluir =
            repositorioTurma.Excluir(id);

        if (!conseguiuExcluir)
            return Result.Fail(
                "Turma não encontrada."
            );

        return Result.Ok();
    }

    public Result<List<ListarTurmaDto>>
        SelecionarTodos()
    {
        List<Turma> turmas =
            repositorioTurma.SelecionarTodos();

        List<ListarTurmaDto> registros =
            mapper.Map<List<ListarTurmaDto>>(turmas);

        return Result.Ok(registros);
    }

    public Result<VisualizarTurmaDto>
        SelecionarPorId(Guid id)
    {
        Turma? turma =
            repositorioTurma.SelecionarPorId(id);

        if (turma is null)
            return Result.Fail(
                "Turma não encontrada."
            );

        VisualizarTurmaDto dto =
            mapper.Map<VisualizarTurmaDto>(turma);

        return Result.Ok(dto);
    }
}
