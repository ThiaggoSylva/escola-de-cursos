using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using EscolaDeCursos.Aplicacao.ModuloCurso.Servicos;
using EscolaDeCursos.Aplicacao.ModuloInstrutor.Servicos;
using EscolaDeCursos.Aplicacao.ModuloTurma.Servicos;
using EscolaDeCursos.Aplicacao.ModuloTurma.DTOs;
using EscolaDeCursos.WebApp.ModuloTurma.Apresentacao.Models;

namespace EscolaDeCursos.WebApp.ModuloTurma.Apresentacao.Controllers;

public class TurmaController : Controller
{
    private readonly ServicoTurma servicoTurma;
    private readonly ServicoCurso servicoCurso;
    private readonly ServicoInstrutor servicoInstrutor;
    private readonly IMapper mapper;

    public TurmaController(
        ServicoTurma servicoTurma,
        ServicoCurso servicoCurso,
        ServicoInstrutor servicoInstrutor,
        IMapper mapper)
    {
        this.servicoTurma = servicoTurma;
        this.servicoCurso = servicoCurso;
        this.servicoInstrutor = servicoInstrutor;
        this.mapper = mapper;
    }

    public IActionResult Listar()
    {
        var resultado = servicoTurma.SelecionarTodos();

        var viewModel =
            mapper.Map<List<ListarTurmaViewModel>>(resultado.Value);

        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Inserir()
    {
        var viewModel = new CadastrarTurmaViewModel();

        CarregarListas(viewModel);

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Inserir(CadastrarTurmaViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            CarregarListas(viewModel);

            return View(viewModel);
        }

        var dto =
            mapper.Map<CadastrarTurmaDto>(viewModel);

        var resultado =
            servicoTurma.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            TempData["Erro"] = resultado.Errors[0].Message;

            CarregarListas(viewModel);

            return View(viewModel);
        }

        TempData["Sucesso"] = "Turma cadastrada com sucesso.";

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public IActionResult Editar(Guid id)
    {
        var resultado = servicoTurma.SelecionarPorId(id);

        if (resultado.IsFailed)
            return RedirectToAction(nameof(Listar));

        var viewModel =
            mapper.Map<EditarTurmaViewModel>(resultado.Value);

        CarregarListas(viewModel);

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Editar(Guid id, EditarTurmaViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            CarregarListas(viewModel);

            return View(viewModel);
        }

        var dto =
            mapper.Map<EditarTurmaDto>(viewModel);

        var resultado =
            servicoTurma.Editar(id, dto);

        if (resultado.IsFailed)
        {
            TempData["Erro"] = resultado.Errors[0].Message;

            CarregarListas(viewModel);

            return View(viewModel);
        }

        TempData["Sucesso"] = "Turma atualizada com sucesso.";

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public IActionResult Excluir(Guid id)
    {
        var resultado = servicoTurma.SelecionarPorId(id);

        if (resultado.IsFailed)
            return RedirectToAction(nameof(Listar));

        var viewModel =
            mapper.Map<ExcluirTurmaViewModel>(resultado.Value);

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult ConfirmarExclusao(Guid id)
    {
        var resultado =
            servicoTurma.Excluir(id);

        if (resultado.IsFailed)
        {
            TempData["Erro"] = resultado.Errors[0].Message;

            return RedirectToAction(nameof(Listar));
        }

        TempData["Sucesso"] = "Turma excluída com sucesso.";

        return RedirectToAction(nameof(Listar));
    }

    private void CarregarListas(FormularioTurmaViewModel viewModel)
    {
        var cursos = servicoCurso.SelecionarTodos();

        viewModel.Cursos =
            cursos.Value.Select(x =>
                new SelectListItem(
                    x.Titulo,
                    x.Id.ToString()))
            .ToList();

        var instrutores = servicoInstrutor.SelecionarTodos();

        viewModel.Instrutores =
            instrutores.Value.Select(x =>
                new SelectListItem(
                    x.Nome,
                    x.Id.ToString()))
            .ToList();
    }
}
