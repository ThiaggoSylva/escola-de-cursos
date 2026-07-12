namespace EscolaDeCursos.Aplicacao.ModuloTurma.DTOs;

public record CadastrarTurmaDto(
    string Nome,
    Guid CursoId,
    Guid InstrutorId,
    DateTime DataInicio,
    DateTime DataTermino,
    int CapacidadeMaxima
);
