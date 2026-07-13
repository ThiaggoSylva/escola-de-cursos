namespace EscolaDeCursos.WebApp.ModuloModulo.Apresentacao.Models;

public class ListarModuloViewModel
{
    public Guid Id { get; set; }

    public string Titulo { get; set; } = string.Empty;

    public int Ordem { get; set; }

    public int Duracao { get; set; }

    public string Curso { get; set; } = string.Empty;
}
