namespace EscolaDeCursos.WebApp.ModuloMatricula.Apresentacao.Models;

public class ExcluirMatriculaViewModel
{
    public Guid Id { get; set; }

    public string Aluno { get; set; } = string.Empty;

    public string Turma { get; set; } = string.Empty;
}
