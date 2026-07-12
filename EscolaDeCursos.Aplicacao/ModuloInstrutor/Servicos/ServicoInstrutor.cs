using AutoMapper;
using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Aplicacao.ModuloInstrutor.DTOs;
using EscolaDeCursos.Dominio;
using FluentResults;

namespace EscolaDeCursos.Aplicacao.ModuloInstrutor.Servicos;

public class ServicoInstrutor : ServicoBase<Instrutor>
{
    private readonly IRepositorioInstrutor repositorioInstrutor;
    private readonly IMapper mapper;

    public ServicoInstrutor(
        IRepositorioInstrutor repositorioInstrutor,
        IMapper mapper)
    {
        this.repositorioInstrutor = repositorioInstrutor;
        this.mapper = mapper;
    }

    public Result<Guid> Cadastrar(
        CadastrarInstrutorDto dto)
    {
        Instrutor instrutor =
            mapper.Map<Instrutor>(dto);

        List<string> erros =
            instrutor.Validar();

        if (repositorioInstrutor.ExisteEmail(instrutor.Email))
        {
            erros.Add(
                "Já existe um instrutor com este e-mail."
            );
        }

        if (repositorioInstrutor.ExisteTelefone(instrutor.Telefone))
        {
            erros.Add(
                "Já existe um instrutor com este telefone."
            );
        }

        if (erros.Any())
            return Result.Fail(erros);

        repositorioInstrutor.Cadastrar(instrutor);

        return Result.Ok(instrutor.Id);
    }

    public Result Editar(
        Guid id,
        EditarInstrutorDto dto)
    {
        Instrutor instrutor =
            mapper.Map<Instrutor>(dto);

        instrutor.Id = id;

        List<string> erros =
            instrutor.Validar();

        if (repositorioInstrutor.ExisteEmail(
            instrutor.Email,
            instrutor.Id))
        {
            erros.Add(
                "Já existe um instrutor com este e-mail."
            );
        }

        if (repositorioInstrutor.ExisteTelefone(
            instrutor.Telefone,
            instrutor.Id))
        {
            erros.Add(
                "Já existe um instrutor com este telefone."
            );
        }

        if (erros.Any())
            return Result.Fail(erros);

        bool conseguiuEditar =
            repositorioInstrutor.Editar(
                instrutor.Id,
                instrutor);

        if (!conseguiuEditar)
            return Result.Fail(
                "Instrutor não encontrado."
            );

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        if (repositorioInstrutor
            .PossuiTurmasVinculadas(id))
        {
            return Result.Fail(
                "Não é possível excluir um instrutor vinculado a turmas."
            );
        }

        bool conseguiuExcluir =
            repositorioInstrutor.Excluir(id);

        if (!conseguiuExcluir)
        {
            return Result.Fail(
                "Instrutor não encontrado."
            );
        }

        return Result.Ok();
    }

    public Result<List<ListarInstrutorDto>>
        SelecionarTodos()
    {
        List<Instrutor> instrutores =
            repositorioInstrutor.SelecionarTodos();

        List<ListarInstrutorDto> registros =
            mapper.Map<List<ListarInstrutorDto>>(instrutores);

        return Result.Ok(registros);
    }

    public Result<VisualizarInstrutorDto>
        SelecionarPorId(Guid id)
    {
        Instrutor? instrutor =
            repositorioInstrutor.SelecionarPorId(id);

        if (instrutor is null)
        {
            return Result.Fail(
                "Instrutor não encontrado."
            );
        }

        VisualizarInstrutorDto dto =
            mapper.Map<VisualizarInstrutorDto>(instrutor);

        return Result.Ok(dto);
    }
}
