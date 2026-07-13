using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using EscolaDeCursos.Aplicacao.ModuloAluno.Servicos;
using EscolaDeCursos.Aplicacao.ModuloAluno.DTOs;
using EscolaDeCursos.WebApp.ModuloAluno.Apresentacao.Models;

namespace EscolaDeCursos.WebApp.ModuloAluno.Apresentacao.Controllers;

public class AlunoController : Controller
{
    private readonly ServicoAluno servicoAluno;
    private readonly IMapper mapper;

    public AlunoController(
        ServicoAluno servicoAluno,
        IMapper mapper)
    {
        this.servicoAluno = servicoAluno;
        this.mapper = mapper;
    }

    public IActionResult Listar()
    {
        var resultado = servicoAluno.SelecionarTodos();

        var viewModel =
            mapper.Map<List<ListarAlunoViewModel>>(resultado.Value);

        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Inserir()
    {
        return View(new CadastrarAlunoViewModel());
    }

    [HttpPost]
    public IActionResult Inserir(CadastrarAlunoViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        var dto =
            mapper.Map<CadastrarAlunoDto>(viewModel);

        var resultado =
            servicoAluno.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            TempData["Erro"] = resultado.Errors[0].Message;

            return View(viewModel);
        }

        TempData["Sucesso"] = "Aluno cadastrado com sucesso.";

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public IActionResult Editar(Guid id)
    {
        var resultado = servicoAluno.SelecionarPorId(id);

        if (resultado.IsFailed)
            return RedirectToAction(nameof(Listar));

        var viewModel =
            mapper.Map<EditarAlunoViewModel>(resultado.Value);

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Editar(Guid id, EditarAlunoViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        var dto =
            mapper.Map<EditarAlunoDto>(viewModel);

        var resultado =
            servicoAluno.Editar(id, dto);

        if (resultado.IsFailed)
        {
            TempData["Erro"] = resultado.Errors[0].Message;

            return View(viewModel);
        }

        TempData["Sucesso"] = "Aluno atualizado com sucesso.";

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public IActionResult Excluir(Guid id)
    {
        var resultado = servicoAluno.SelecionarPorId(id);

        if (resultado.IsFailed)
            return RedirectToAction(nameof(Listar));

        var viewModel =
            mapper.Map<ExcluirAlunoViewModel>(resultado.Value);

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult ConfirmarExclusao(Guid id)
    {
        var resultado =
            servicoAluno.Excluir(id);

        if (resultado.IsFailed)
        {
            TempData["Erro"] = resultado.Errors[0].Message;

            return RedirectToAction(nameof(Listar));
        }

        TempData["Sucesso"] = "Aluno excluído com sucesso.";

        return RedirectToAction(nameof(Listar));
    }
}
