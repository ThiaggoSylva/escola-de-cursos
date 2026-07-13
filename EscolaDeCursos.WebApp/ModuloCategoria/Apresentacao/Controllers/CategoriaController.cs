using AutoMapper;
using EscolaDeCursos.Aplicacao.ModuloCategoria.DTOs;
using EscolaDeCursos.Aplicacao.ModuloCategoria.Servicos;
using EscolaDeCursos.ModuloCategoria.Apresentacao.Models;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.ModuloCategoria.Apresentacao.Controllers;

public class CategoriaController : Controller
{
    private readonly ServicoCategoria servicoCategoria;
    private readonly IMapper mapper;

    public CategoriaController(
        ServicoCategoria servicoCategoria,
        IMapper mapper)
    {
        this.servicoCategoria = servicoCategoria;
        this.mapper = mapper;
    }

    public IActionResult Listar()
    {
        var resultado = servicoCategoria.SelecionarTodos();

        var viewModel =
            mapper.Map<List<ListarCategoriaViewModel>>(resultado.Value);

        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Inserir()
    {
        return View(new CadastrarCategoriaViewModel());
    }

    [HttpPost]
    public IActionResult Inserir(CadastrarCategoriaViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        var dto =
            mapper.Map<CadastrarCategoriaDto>(viewModel);

        var resultado =
            servicoCategoria.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            TempData["Erro"] = resultado.Errors[0].Message;
            return View(viewModel);
        }

        TempData["Sucesso"] = "Categoria cadastrada com sucesso.";

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public IActionResult Editar(Guid id)
    {
        var resultado = servicoCategoria.SelecionarPorId(id);

        if (resultado.IsFailed)
            return RedirectToAction(nameof(Listar));

        var viewModel =
            mapper.Map<EditarCategoriaViewModel>(resultado.Value);

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Editar(
        Guid id,
        EditarCategoriaViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        var dto =
            mapper.Map<EditarCategoriaDto>(viewModel);

        var resultado =
            servicoCategoria.Editar(id, dto);

        if (resultado.IsFailed)
        {
            TempData["Erro"] = resultado.Errors[0].Message;
            return View(viewModel);
        }

        TempData["Sucesso"] = "Categoria editada com sucesso.";

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public IActionResult Excluir(Guid id)
    {
        var resultado = servicoCategoria.SelecionarPorId(id);

        if (resultado.IsFailed)
            return RedirectToAction(nameof(Listar));

        var viewModel =
            mapper.Map<ExcluirCategoriaViewModel>(resultado.Value);

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult ConfirmarExclusao(Guid id)
    {
        var resultado = servicoCategoria.Excluir(id);

        if (resultado.IsFailed)
        {
            TempData["Erro"] = resultado.Errors[0].Message;
            return RedirectToAction(nameof(Listar));
        }

        TempData["Sucesso"] = "Categoria excluída com sucesso.";

        return RedirectToAction(nameof(Listar));
    }
}
