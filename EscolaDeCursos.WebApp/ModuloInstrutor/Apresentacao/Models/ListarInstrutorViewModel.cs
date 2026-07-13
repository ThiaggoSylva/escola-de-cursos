namespace EscolaDeCursos.WebApp.ModuloInstrutor.Apresentacao.Models;

public class ListarInstrutorViewModel
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Telefone { get; set; } = string.Empty;

    public string Especialidade { get; set; } = string.Empty;
}
