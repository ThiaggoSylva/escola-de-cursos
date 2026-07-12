using System.ComponentModel.DataAnnotations;

namespace EscolaDeCursos.ModuloCategoria.Apresentacao.Models;

public class EditarCategoriaViewModel: FormularioCategoriaViewModel
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Titulo { get; set; } = string.Empty;
}
