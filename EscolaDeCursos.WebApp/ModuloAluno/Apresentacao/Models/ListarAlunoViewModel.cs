namespace EscolaDeCursos.WebApp.ModuloAluno.Apresentacao.Models;

public class ListarAlunoViewModel
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Telefone { get; set; } = string.Empty;

    public string CPF { get; set; } = string.Empty;
}
