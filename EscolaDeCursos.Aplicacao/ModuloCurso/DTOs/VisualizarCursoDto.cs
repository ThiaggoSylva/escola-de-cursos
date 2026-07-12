namespace EscolaDeCursos.Aplicacao.ModuloCurso.DTOs;

public record VisualizarCursoDto(
    Guid Id,
    string Titulo,
    string Descricao,
    int CargaHoraria,
    string Nivel,
    Guid CategoriaId,
    string Categoria
);
