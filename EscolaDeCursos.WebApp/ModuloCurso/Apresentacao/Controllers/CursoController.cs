using AutoMapper;
using EscolaDeCursos.Aplicacao.ModuloCategoria.Servicos;
using EscolaDeCursos.Aplicacao.ModuloCurso.DTOs;
using EscolaDeCursos.Aplicacao.ModuloCurso.Servicos;
using EscolaDeCursos.ModuloCurso.Apresentacao.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EscolaDeCursos.ModuloCurso.Apresentacao.Controllers;

public class CursoController : Controller
{
    private readonly ServicoCurso servicoCurso;
    private readonly ServicoCategoria servicoCategoria;
    private readonly IMapper mapper;

    public CursoController(
        ServicoCurso servicoCurso,
        ServicoCategoria servicoCategoria,
        IMapper mapper)
    {
        this.servicoCurso = servicoCurso;
        this.servicoCategoria = servicoCategoria;
        this.mapper = mapper;
    }

    public IActionResult Listar()
    {
        var resultado = servicoCurso.SelecionarTodos();

        var registros = mapper.Map<List<ListarCursoViewModel>>(
            resultado.Value);

        return View(registros);
    }

    [HttpGet]
    public IActionResult Inserir()
    {
        var vm = new CadastrarCursoViewModel();

        CarregarCategorias(vm);

        return View(vm);
    }

    [HttpPost]
    public IActionResult Inserir(
        CadastrarCursoViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            CarregarCategorias(vm);

            return View(vm);
        }

        var dto = mapper.Map<CadastrarCursoDto>(vm);

        var resultado = servicoCurso.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            foreach (var erro in resultado.Errors)
                ModelState.AddModelError(
                    string.Empty,
                    erro.Message);

            CarregarCategorias(vm);

            return View(vm);
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public IActionResult Editar(Guid id)
    {
        var resultado = servicoCurso.SelecionarPorId(id);

        if (resultado.IsFailed)
            return RedirectToAction(nameof(Listar));

        var vm =
            mapper.Map<EditarCursoViewModel>(
                resultado.Value);

        CarregarCategorias(vm);

        return View(vm);
    }

    [HttpPost]
    public IActionResult Editar(
        Guid id,
        EditarCursoViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            CarregarCategorias(vm);

            return View(vm);
        }

        var dto = mapper.Map<EditarCursoDto>(vm);

        var resultado = servicoCurso.Editar(id, dto);

        if (resultado.IsFailed)
        {
            foreach (var erro in resultado.Errors)
                ModelState.AddModelError(
                    string.Empty,
                    erro.Message);

            CarregarCategorias(vm);

            return View(vm);
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public IActionResult Excluir(Guid id)
    {
        var resultado = servicoCurso.SelecionarPorId(id);

        if (resultado.IsFailed)
            return RedirectToAction(nameof(Listar));

        var vm =
            mapper.Map<ExcluirCursoViewModel>(
                resultado.Value);

        return View(vm);
    }

    [HttpPost]
public IActionResult ConfirmarExclusao(Guid id)
{
    var resultado = servicoCurso.Excluir(id);

    if (resultado.IsFailed)
    {
        TempData["Erro"] =
            resultado.Errors.First().Message;
    }

    return RedirectToAction(nameof(Listar));
}

    private void CarregarCategorias(
        FormularioCursoViewModel vm)
    {
        var categorias =
            servicoCategoria.SelecionarTodos();

        vm.Categorias =
            categorias.Value.Select(x =>
                new SelectListItem(
                    x.Titulo,
                    x.Id.ToString()))
            .ToList();
    }
}
