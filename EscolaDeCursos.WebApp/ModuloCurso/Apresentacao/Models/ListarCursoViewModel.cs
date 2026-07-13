namespace EscolaDeCursos.ModuloCurso.Apresentacao.Models;

public class ListarCursoViewModel
{
    public Guid Id { get; set; }

    public string Titulo { get; set; } = string.Empty;

    public string Categoria { get; set; } = string.Empty;

    public string Nivel { get; set; } = string.Empty;

    public int CargaHoraria { get; set; }
}
