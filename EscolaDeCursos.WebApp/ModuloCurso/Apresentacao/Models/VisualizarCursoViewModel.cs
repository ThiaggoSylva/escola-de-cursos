namespace EscolaDeCursos.ModuloCurso.Apresentacao.Models;

public class VisualizarCursoViewModel
{
    public Guid Id { get; set; }

    public string Titulo { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public int CargaHoraria { get; set; }

    public string Nivel { get; set; } = string.Empty;

    public Guid CategoriaId { get; set; }

    public string Categoria { get; set; } = string.Empty;
}
