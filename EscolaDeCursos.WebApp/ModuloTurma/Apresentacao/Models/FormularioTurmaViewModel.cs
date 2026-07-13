using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EscolaDeCursos.WebApp.ModuloTurma.Apresentacao.Models;

public abstract class FormularioTurmaViewModel
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(100, MinimumLength = 2)]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O curso é obrigatório.")]
    public Guid CursoId { get; set; }

    public List<SelectListItem> Cursos { get; set; } = [];

    [Required(ErrorMessage = "O instrutor é obrigatório.")]
    public Guid InstrutorId { get; set; }

    public List<SelectListItem> Instrutores { get; set; } = [];

    [Required(ErrorMessage = "A data de início é obrigatória.")]
    [DataType(DataType.Date)]
    [Display(Name = "Data de Início")]
    public DateTime DataInicio { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "A data de término é obrigatória.")]
    [DataType(DataType.Date)]
    [Display(Name = "Data de Término")]
    public DateTime DataTermino { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "A capacidade máxima é obrigatória.")]
    [Range(1, int.MaxValue, ErrorMessage = "A capacidade máxima deve ser maior que zero.")]
    [Display(Name = "Capacidade Máxima")]
    public int CapacidadeMaxima { get; set; }
}
