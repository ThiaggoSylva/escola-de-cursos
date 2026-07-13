namespace EscolaDeCursos.WebApp.ModuloMatricula.Apresentacao.Models;

public class ListarMatriculaViewModel
{
    public Guid Id { get; set; }

    public string Aluno { get; set; } = string.Empty;

    public string Turma { get; set; } = string.Empty;

    public DateTime DataMatricula { get; set; }

    public string Situacao { get; set; } = string.Empty;
}
