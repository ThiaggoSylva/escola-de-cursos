using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using EscolaDeCursos.Aplicacao.ModuloCurso.Servicos;
using EscolaDeCursos.Aplicacao.ModuloModulo.Servicos;
using EscolaDeCursos.Aplicacao.ModuloModulo.DTOs;
using EscolaDeCursos.WebApp.ModuloModulo.Apresentacao.Models;

namespace EscolaDeCursos.WebApp.ModuloModulo.Apresentacao.Controllers;

public class ModuloController : Controller
{
    private readonly ServicoModulo servicoModulo;
    private readonly ServicoCurso servicoCurso;
    private readonly IMapper mapper;

    public ModuloController(
        ServicoModulo servicoModulo,
        ServicoCurso servicoCurso,
        IMapper mapper)
    {
        this.servicoModulo = servicoModulo;
        this.servicoCurso = servicoCurso;
        this.mapper = mapper;
    }

    public IActionResult Listar()
    {
        var resultado = servicoModulo.SelecionarTodos();

        var viewModel =
            mapper.Map<List<ListarModuloViewModel>>(resultado.Value);

        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Inserir()
    {
        var viewModel = new CadastrarModuloViewModel();

        CarregarCursos(viewModel);

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Inserir(CadastrarModuloViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            CarregarCursos(viewModel);

            return View(viewModel);
        }

        var dto =
            mapper.Map<CadastrarModuloDto>(viewModel);

        var resultado =
            servicoModulo.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            TempData["Erro"] = resultado.Errors[0].Message;

            CarregarCursos(viewModel);

            return View(viewModel);
        }

        TempData["Sucesso"] = "Módulo cadastrado com sucesso.";

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public IActionResult Editar(Guid id)
    {
        var resultado = servicoModulo.SelecionarPorId(id);

        if (resultado.IsFailed)
            return RedirectToAction(nameof(Listar));

        var viewModel =
            mapper.Map<EditarModuloViewModel>(resultado.Value);

        CarregarCursos(viewModel);

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Editar(Guid id, EditarModuloViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            CarregarCursos(viewModel);

            return View(viewModel);
        }

        var dto =
            mapper.Map<EditarModuloDto>(viewModel);

        var resultado =
            servicoModulo.Editar(id, dto);

        if (resultado.IsFailed)
        {
            TempData["Erro"] = resultado.Errors[0].Message;

            CarregarCursos(viewModel);

            return View(viewModel);
        }

        TempData["Sucesso"] = "Módulo atualizado com sucesso.";

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public IActionResult Excluir(Guid id)
    {
        var resultado = servicoModulo.SelecionarPorId(id);

        if (resultado.IsFailed)
            return RedirectToAction(nameof(Listar));

        var viewModel =
            mapper.Map<ExcluirModuloViewModel>(resultado.Value);

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult ConfirmarExclusao(Guid id)
    {
        var resultado =
            servicoModulo.Excluir(id);

        if (resultado.IsFailed)
        {
            TempData["Erro"] = resultado.Errors[0].Message;

            return RedirectToAction(nameof(Listar));
        }

        TempData["Sucesso"] = "Módulo excluído com sucesso.";

        return RedirectToAction(nameof(Listar));
    }

    private void CarregarCursos(FormularioModuloViewModel viewModel)
    {
        var cursos = servicoCurso.SelecionarTodos();

        viewModel.Cursos =
            cursos.Value.Select(x =>
                new SelectListItem(
                    x.Titulo,
                    x.Id.ToString()))
            .ToList();
    }
}
