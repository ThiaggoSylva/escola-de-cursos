namespace EscolaDeCursos.Aplicacao.ModuloMatricula.DTOs;

public record VisualizarMatriculaDto(
    Guid Id,
    Guid AlunoId,
    string Aluno,
    Guid TurmaId,
    string Turma,
    DateTime DataMatricula,
    string Situacao
);
