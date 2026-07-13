namespace EscolaDeCursos.WebApp.ModuloTurma.Apresentacao.Models;

public class ListarTurmaViewModel
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Curso { get; set; } = string.Empty;

    public string Instrutor { get; set; } = string.Empty;

    public DateTime DataInicio { get; set; }

    public DateTime DataTermino { get; set; }

    public int CapacidadeMaxima { get; set; }
}
