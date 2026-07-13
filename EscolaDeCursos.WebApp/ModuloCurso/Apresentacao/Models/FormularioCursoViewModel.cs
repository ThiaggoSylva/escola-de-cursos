using System.ComponentModel.DataAnnotations;
using EscolaDeCursos.Dominio.Enumeradores;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EscolaDeCursos.ModuloCurso.Apresentacao.Models;

public abstract class FormularioCursoViewModel
{
    [Required(ErrorMessage = "O título é obrigatório.")]
    [StringLength(100, MinimumLength = 2)]
    public string Titulo { get; set; } = string.Empty;

    [Required(ErrorMessage = "A descrição é obrigatória.")]
    public string Descricao { get; set; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int CargaHoraria { get; set; }

    [Required]
    public NivelCurso Nivel { get; set; }

    [Required]
    public Guid CategoriaId { get; set; }

    public List<SelectListItem> Categorias { get; set; } = [];
}
