using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using EscolaDeCursos.Aplicacao.ModuloInstrutor.Servicos;
using EscolaDeCursos.Aplicacao.ModuloInstrutor.DTOs;
using EscolaDeCursos.WebApp.ModuloInstrutor.Apresentacao.Models;

namespace EscolaDeCursos.WebApp.ModuloInstrutor.Apresentacao.Controllers;

public class InstrutorController : Controller
{
    private readonly ServicoInstrutor servicoInstrutor;
    private readonly IMapper mapper;

    public InstrutorController(
        ServicoInstrutor servicoInstrutor,
        IMapper mapper)
    {
        this.servicoInstrutor = servicoInstrutor;
        this.mapper = mapper;
    }

    public IActionResult Listar()
    {
        var resultado = servicoInstrutor.SelecionarTodos();

        var viewModel =
            mapper.Map<List<ListarInstrutorViewModel>>(resultado.Value);

        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Inserir()
    {
        return View(new CadastrarInstrutorViewModel());
    }

    [HttpPost]
    public IActionResult Inserir(CadastrarInstrutorViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        var dto =
            mapper.Map<CadastrarInstrutorDto>(viewModel);

        var resultado =
            servicoInstrutor.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            TempData["Erro"] = resultado.Errors[0].Message;

            return View(viewModel);
        }

        TempData["Sucesso"] = "Instrutor cadastrado com sucesso.";

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public IActionResult Editar(Guid id)
    {
        var resultado = servicoInstrutor.SelecionarPorId(id);

        if (resultado.IsFailed)
            return RedirectToAction(nameof(Listar));

        var viewModel =
            mapper.Map<EditarInstrutorViewModel>(resultado.Value);

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Editar(Guid id, EditarInstrutorViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        var dto =
            mapper.Map<EditarInstrutorDto>(viewModel);

        var resultado =
            servicoInstrutor.Editar(id, dto);

        if (resultado.IsFailed)
        {
            TempData["Erro"] = resultado.Errors[0].Message;

            return View(viewModel);
        }

        TempData["Sucesso"] = "Instrutor atualizado com sucesso.";

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public IActionResult Excluir(Guid id)
    {
        var resultado = servicoInstrutor.SelecionarPorId(id);

        if (resultado.IsFailed)
            return RedirectToAction(nameof(Listar));

        var viewModel =
            mapper.Map<ExcluirInstrutorViewModel>(resultado.Value);

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult ConfirmarExclusao(Guid id)
    {
        var resultado =
            servicoInstrutor.Excluir(id);

        if (resultado.IsFailed)
        {
            TempData["Erro"] = resultado.Errors[0].Message;

            return RedirectToAction(nameof(Listar));
        }

        TempData["Sucesso"] = "Instrutor excluído com sucesso.";

        return RedirectToAction(nameof(Listar));
    }
}
