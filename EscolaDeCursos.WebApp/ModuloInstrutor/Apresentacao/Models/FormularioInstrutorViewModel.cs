using System.ComponentModel.DataAnnotations;

namespace EscolaDeCursos.WebApp.ModuloInstrutor.Apresentacao.Models;

public class FormularioInstrutorViewModel
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MinLength(2)]
    [MaxLength(100)]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O telefone é obrigatório.")]
    public string Telefone { get; set; } = string.Empty;

    [Required(ErrorMessage = "A especialidade é obrigatória.")]
    public string Especialidade { get; set; } = string.Empty;
}
