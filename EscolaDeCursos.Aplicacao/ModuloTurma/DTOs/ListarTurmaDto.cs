namespace EscolaDeCursos.Aplicacao.ModuloTurma.DTOs;

public record ListarTurmaDto(
    Guid Id,
    string Nome,
    string Curso,
    string Instrutor,
    DateTime DataInicio,
    DateTime DataTermino,
    int CapacidadeMaxima
);
