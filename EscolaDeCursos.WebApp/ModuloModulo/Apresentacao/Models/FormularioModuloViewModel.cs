using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EscolaDeCursos.WebApp.ModuloModulo.Apresentacao.Models;

public abstract class FormularioModuloViewModel
{
    [Required(ErrorMessage = "O título é obrigatório.")]
    [StringLength(100, MinimumLength = 2)]
    public string Titulo { get; set; } = string.Empty;

    [Required(ErrorMessage = "A ordem é obrigatória.")]
    [Range(1, int.MaxValue, ErrorMessage = "A ordem deve ser maior que zero.")]
    public int Ordem { get; set; }

    [Required(ErrorMessage = "A duração é obrigatória.")]
    [Range(1, int.MaxValue, ErrorMessage = "A duração deve ser maior que zero.")]
    [Display(Name = "Duração (horas)")]
    public int Duracao { get; set; }

    [Required(ErrorMessage = "O curso é obrigatório.")]
    public Guid CursoId { get; set; }

    public List<SelectListItem> Cursos { get; set; } = [];
}
