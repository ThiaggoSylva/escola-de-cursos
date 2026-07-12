namespace EscolaDeCursos.Aplicacao.ModuloModulo.DTOs;

public record VisualizarModuloDto(
    Guid Id,
    string Titulo,
    int Ordem,
    int Duracao,
    Guid CursoId,
    string Curso
);
