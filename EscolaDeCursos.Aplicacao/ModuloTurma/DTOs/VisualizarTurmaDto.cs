namespace EscolaDeCursos.Aplicacao.ModuloTurma.DTOs;

public record VisualizarTurmaDto(
    Guid Id,
    string Nome,
    Guid CursoId,
    string Curso,
    Guid InstrutorId,
    string Instrutor,
    DateTime DataInicio,
    DateTime DataTermino,
    int CapacidadeMaxima
);
