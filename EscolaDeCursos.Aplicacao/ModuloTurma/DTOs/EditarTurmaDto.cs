namespace EscolaDeCursos.Aplicacao.ModuloTurma.DTOs;

public record EditarTurmaDto(
    Guid Id,
    string Nome,
    Guid CursoId,
    Guid InstrutorId,
    DateTime DataInicio,
    DateTime DataTermino,
    int CapacidadeMaxima
);
