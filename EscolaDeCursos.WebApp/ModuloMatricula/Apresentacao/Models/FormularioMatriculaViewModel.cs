using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using EscolaDeCursos.Dominio.Enumeradores;

namespace EscolaDeCursos.WebApp.ModuloMatricula.Apresentacao.Models;

public abstract class FormularioMatriculaViewModel
{
    [Required(ErrorMessage = "O aluno é obrigatório.")]
    public Guid AlunoId { get; set; }

    public List<SelectListItem> Alunos { get; set; } = [];

    [Required(ErrorMessage = "A turma é obrigatória.")]
    public Guid TurmaId { get; set; }

    public List<SelectListItem> Turmas { get; set; } = [];

    [Required(ErrorMessage = "A data da matrícula é obrigatória.")]
    [DataType(DataType.Date)]
    [Display(Name = "Data da Matrícula")]
    public DateTime DataMatricula { get; set; } = DateTime.Today;

    [Required]
    public SituacaoMatricula Situacao { get; set; } = SituacaoMatricula.Ativa;
}
