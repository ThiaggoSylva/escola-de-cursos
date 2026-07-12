using AutoMapper;
using EscolaDeCursos.Aplicacao.ModuloCategoria.DTOs;
using EscolaDeCursos.Aplicacao.ModuloCategoria.Servicos;
using EscolaDeCursos.ModuloCategoria.Apresentacao.Models;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.ModuloCategoria.Apresentacao.Controllers;

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

        var registros =
            mapper.Map<List<ListarCategoriaViewModel>>(
                resultado.Value);

        return View(registros);
    }

    [HttpGet]
    public IActionResult Inserir()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Inserir(
        CadastrarCategoriaViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        var dto =
            mapper.Map<CadastrarCategoriaDto>(viewModel);

        Result<Guid> resultado =
            servicoCategoria.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            foreach (var erro in resultado.Errors)
                ModelState.AddModelError(
                    string.Empty,
                    erro.Message);

            return View(viewModel);
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public IActionResult Editar(Guid id)
    {
        var resultado =
            servicoCategoria.SelecionarPorId(id);

        if (resultado.IsFailed)
            return RedirectToAction(nameof(Listar));

        var viewModel =
            mapper.Map<EditarCategoriaViewModel>(
                resultado.Value);

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
            foreach (var erro in resultado.Errors)
                ModelState.AddModelError(
                    string.Empty,
                    erro.Message);

            return View(viewModel);
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public IActionResult Excluir(Guid id)
    {
        var resultado =
            servicoCategoria.SelecionarPorId(id);

        if (resultado.IsFailed)
            return RedirectToAction(nameof(Listar));

        var viewModel =
            mapper.Map<ExcluirCategoriaViewModel>(
                resultado.Value);

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult ConfirmarExclusao(Guid id)
    {
        var resultado =
            servicoCategoria.Excluir(id);

        if (resultado.IsFailed)
        {
            TempData["Erro"] =
                resultado.Errors.First().Message;
        }

        return RedirectToAction(nameof(Listar));
    }
}
