using AutoMapper;
using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Aplicacao.ModuloMatricula.DTOs;
using EscolaDeCursos.Dominio;
using EscolaDeCursos.Dominio.Enumeradores;
using FluentResults;

namespace EscolaDeCursos.Aplicacao.ModuloMatricula.Servicos;

public class ServicoMatricula : ServicoBase<Matricula>
{
    private readonly IRepositorioMatricula repositorioMatricula;
    private readonly IRepositorioAluno repositorioAluno;
    private readonly IRepositorioTurma repositorioTurma;
    private readonly IMapper mapper;

    public ServicoMatricula(
        IRepositorioMatricula repositorioMatricula,
        IRepositorioAluno repositorioAluno,
        IRepositorioTurma repositorioTurma,
        IMapper mapper)
    {
        this.repositorioMatricula = repositorioMatricula;
        this.repositorioAluno = repositorioAluno;
        this.repositorioTurma = repositorioTurma;
        this.mapper = mapper;
    }

    public Result<Guid> Cadastrar(
        CadastrarMatriculaDto dto)
    {
        Matricula matricula =
            mapper.Map<Matricula>(dto);

        List<string> erros =
            matricula.Validar();

        Aluno? aluno =
            repositorioAluno.SelecionarPorId(dto.AlunoId);

        if (aluno is null)
            erros.Add("Aluno não encontrado.");

        Turma? turma =
            repositorioTurma.SelecionarPorId(dto.TurmaId);

        if (turma is null)
            erros.Add("Turma não encontrada.");

        if (repositorioMatricula.AlunoJaMatriculado(
            dto.AlunoId,
            dto.TurmaId))
        {
            erros.Add(
                "O aluno já está matriculado nesta turma."
            );
        }

        if (turma is not null)
        {
            int totalMatriculas =
                repositorioMatricula
                    .SelecionarPorTurma(dto.TurmaId)
                    .Count;

            if (totalMatriculas >= turma.CapacidadeMaxima)
            {
                erros.Add(
                    "A turma atingiu sua capacidade máxima."
                );
            }

            if (dto.DataMatricula > turma.DataInicio)
            {
                erros.Add(
                    "A data da matrícula deve ser igual ou anterior ao início da turma."
                );
            }
        }

        if (erros.Any())
            return Result.Fail(erros);

        repositorioMatricula.Cadastrar(matricula);

        return Result.Ok(matricula.Id);
    }

    public Result Editar(
        Guid id,
        EditarMatriculaDto dto)
    {
        Matricula matricula =
            mapper.Map<Matricula>(dto);

        matricula.Id = id;

        List<string> erros =
            matricula.Validar();

        Turma? turma =
            repositorioTurma.SelecionarPorId(dto.TurmaId);

        if (repositorioMatricula.AlunoJaMatriculado(
            dto.AlunoId,
            dto.TurmaId,
            id))
        {
            erros.Add(
                "O aluno já está matriculado nesta turma."
            );
        }

        if (turma is not null &&
            dto.DataMatricula > turma.DataInicio)
        {
            erros.Add(
                "A data da matrícula deve ser igual ou anterior ao início da turma."
            );
        }

        if (erros.Any())
            return Result.Fail(erros);

        bool conseguiuEditar =
            repositorioMatricula.Editar(
                matricula.Id,
                matricula);

        if (!conseguiuEditar)
            return Result.Fail(
                "Matrícula não encontrada."
            );

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Matricula? matricula =
            repositorioMatricula.SelecionarPorId(id);

        if (matricula is null)
            return Result.Fail(
                "Matrícula não encontrada."
            );

        if (matricula.Situacao ==
            SituacaoMatricula.Concluida)
        {
            return Result.Fail(
                "Matrículas concluídas devem permanecer para histórico."
            );
        }

        repositorioMatricula.Excluir(id);

        return Result.Ok();
    }

    public Result<List<ListarMatriculaDto>>
        SelecionarTodos()
    {
        List<Matricula> matriculas =
            repositorioMatricula.SelecionarTodos();

        List<ListarMatriculaDto> registros =
            mapper.Map<List<ListarMatriculaDto>>(matriculas);

        return Result.Ok(registros);
    }

    public Result<VisualizarMatriculaDto>
        SelecionarPorId(Guid id)
    {
        Matricula? matricula =
            repositorioMatricula.SelecionarPorId(id);

        if (matricula is null)
            return Result.Fail(
                "Matrícula não encontrada."
            );

        VisualizarMatriculaDto dto =
            mapper.Map<VisualizarMatriculaDto>(matricula);

        return Result.Ok(dto);
    }

    public Result<List<ListarMatriculaDto>>
        SelecionarPorAluno(Guid alunoId)
    {
        List<Matricula> matriculas =
            repositorioMatricula
                .SelecionarPorAluno(alunoId);

        List<ListarMatriculaDto> registros =
            mapper.Map<List<ListarMatriculaDto>>(matriculas);

        return Result.Ok(registros);
    }

    public Result<List<ListarMatriculaDto>>
        SelecionarPorTurma(Guid turmaId)
    {
        List<Matricula> matriculas =
            repositorioMatricula
                .SelecionarPorTurma(turmaId);

        List<ListarMatriculaDto> registros =
            mapper.Map<List<ListarMatriculaDto>>(matriculas);

        return Result.Ok(registros);
    }
}
