using AutoMapper;
using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Aplicacao.ModuloAluno.DTOs;
using EscolaDeCursos.Dominio;
using FluentResults;

namespace EscolaDeCursos.Aplicacao.ModuloAluno.Servicos;

public class ServicoAluno : ServicoBase<Aluno>
{
    private readonly IRepositorioAluno repositorioAluno;
    private readonly IMapper mapper;

    public ServicoAluno(
        IRepositorioAluno repositorioAluno,
        IMapper mapper)
    {
        this.repositorioAluno = repositorioAluno;
        this.mapper = mapper;
    }

    public Result<Guid> Cadastrar(
        CadastrarAlunoDto dto)
    {
        Aluno aluno =
            mapper.Map<Aluno>(dto);

        List<string> erros =
            aluno.Validar();

        if (repositorioAluno.ExisteCpf(aluno.CPF))
            erros.Add("Já existe um aluno com este CPF.");

        if (repositorioAluno.ExisteEmail(aluno.Email))
            erros.Add("Já existe um aluno com este e-mail.");

        if (repositorioAluno.ExisteTelefone(aluno.Telefone))
            erros.Add("Já existe um aluno com este telefone.");

        if (erros.Any())
            return Result.Fail(erros);

        repositorioAluno.Cadastrar(aluno);

        return Result.Ok(aluno.Id);
    }

    public Result Editar(
        Guid id,
        EditarAlunoDto dto)
    {
        Aluno aluno =
            mapper.Map<Aluno>(dto);

        aluno.Id = id;

        List<string> erros =
            aluno.Validar();

        if (repositorioAluno.ExisteCpf(
            aluno.CPF,
            aluno.Id))
        {
            erros.Add(
                "Já existe um aluno com este CPF."
            );
        }

        if (repositorioAluno.ExisteEmail(
            aluno.Email,
            aluno.Id))
        {
            erros.Add(
                "Já existe um aluno com este e-mail."
            );
        }

        if (repositorioAluno.ExisteTelefone(
            aluno.Telefone,
            aluno.Id))
        {
            erros.Add(
                "Já existe um aluno com este telefone."
            );
        }

        if (erros.Any())
            return Result.Fail(erros);

        bool conseguiuEditar =
            repositorioAluno.Editar(
                aluno.Id,
                aluno);

        if (!conseguiuEditar)
            return Result.Fail(
                "Aluno não encontrado."
            );

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        if (repositorioAluno
            .PossuiMatriculasVinculadas(id))
        {
            return Result.Fail(
                "Não é possível excluir um aluno com matrículas vinculadas."
            );
        }

        bool conseguiuExcluir =
            repositorioAluno.Excluir(id);

        if (!conseguiuExcluir)
        {
            return Result.Fail(
                "Aluno não encontrado."
            );
        }

        return Result.Ok();
    }

    public Result<List<ListarAlunoDto>>
        SelecionarTodos()
    {
        List<Aluno> alunos =
            repositorioAluno.SelecionarTodos();

        List<ListarAlunoDto> registros =
            mapper.Map<List<ListarAlunoDto>>(alunos);

        return Result.Ok(registros);
    }

    public Result<VisualizarAlunoDto>
        SelecionarPorId(Guid id)
    {
        Aluno? aluno =
            repositorioAluno.SelecionarPorId(id);

        if (aluno is null)
        {
            return Result.Fail(
                "Aluno não encontrado."
            );
        }

        VisualizarAlunoDto dto =
            mapper.Map<VisualizarAlunoDto>(aluno);

        return Result.Ok(dto);
    }
}
