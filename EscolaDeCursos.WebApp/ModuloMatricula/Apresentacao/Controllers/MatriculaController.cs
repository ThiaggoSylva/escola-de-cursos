using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using EscolaDeCursos.Aplicacao.ModuloAluno.Servicos;
using EscolaDeCursos.Aplicacao.ModuloTurma.Servicos;
using EscolaDeCursos.Aplicacao.ModuloMatricula.Servicos;
using EscolaDeCursos.Aplicacao.ModuloMatricula.DTOs;
using EscolaDeCursos.WebApp.ModuloMatricula.Apresentacao.Models;

namespace EscolaDeCursos.WebApp.ModuloMatricula.Apresentacao.Controllers;

public class MatriculaController : Controller
{
    private readonly ServicoMatricula servicoMatricula;
    private readonly ServicoAluno servicoAluno;
    private readonly ServicoTurma servicoTurma;
    private readonly IMapper mapper;

    public MatriculaController(
        ServicoMatricula servicoMatricula,
        ServicoAluno servicoAluno,
        ServicoTurma servicoTurma,
        IMapper mapper)
    {
        this.servicoMatricula = servicoMatricula;
        this.servicoAluno = servicoAluno;
        this.servicoTurma = servicoTurma;
        this.mapper = mapper;
    }

    public IActionResult Listar()
    {
        var resultado = servicoMatricula.SelecionarTodos();

        var viewModel =
            mapper.Map<List<ListarMatriculaViewModel>>(resultado.Value);

        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Inserir()
    {
        var viewModel = new CadastrarMatriculaViewModel();

        CarregarListas(viewModel);

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Inserir(CadastrarMatriculaViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            CarregarListas(viewModel);

            return View(viewModel);
        }

        var dto =
            mapper.Map<CadastrarMatriculaDto>(viewModel);

        var resultado =
            servicoMatricula.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            TempData["Erro"] = resultado.Errors[0].Message;

            CarregarListas(viewModel);

            return View(viewModel);
        }

        TempData["Sucesso"] = "Matrícula cadastrada com sucesso.";

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public IActionResult Editar(Guid id)
    {
        var resultado = servicoMatricula.SelecionarPorId(id);

        if (resultado.IsFailed)
            return RedirectToAction(nameof(Listar));

        var viewModel =
            mapper.Map<EditarMatriculaViewModel>(resultado.Value);

        CarregarListas(viewModel);

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Editar(Guid id, EditarMatriculaViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            CarregarListas(viewModel);

            return View(viewModel);
        }

        var dto =
            mapper.Map<EditarMatriculaDto>(viewModel);

        var resultado =
            servicoMatricula.Editar(id, dto);

        if (resultado.IsFailed)
        {
            TempData["Erro"] = resultado.Errors[0].Message;

            CarregarListas(viewModel);

            return View(viewModel);
        }

        TempData["Sucesso"] = "Matrícula atualizada com sucesso.";

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public IActionResult Excluir(Guid id)
    {
        var resultado = servicoMatricula.SelecionarPorId(id);

        if (resultado.IsFailed)
            return RedirectToAction(nameof(Listar));

        var viewModel =
            mapper.Map<ExcluirMatriculaViewModel>(resultado.Value);

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult ConfirmarExclusao(Guid id)
    {
        var resultado =
            servicoMatricula.Excluir(id);

        if (resultado.IsFailed)
        {
            TempData["Erro"] = resultado.Errors[0].Message;

            return RedirectToAction(nameof(Listar));
        }

        TempData["Sucesso"] = "Matrícula excluída com sucesso.";

        return RedirectToAction(nameof(Listar));
    }

    private void CarregarListas(FormularioMatriculaViewModel viewModel)
    {
        var alunos = servicoAluno.SelecionarTodos();

        viewModel.Alunos =
            alunos.Value.Select(x =>
                new SelectListItem(
                    x.Nome,
                    x.Id.ToString()))
            .ToList();

        var turmas = servicoTurma.SelecionarTodos();

        viewModel.Turmas =
            turmas.Value.Select(x =>
                new SelectListItem(
                    x.Nome,
                    x.Id.ToString()))
            .ToList();
    }
}
