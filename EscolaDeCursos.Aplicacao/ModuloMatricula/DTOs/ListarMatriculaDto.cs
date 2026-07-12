namespace EscolaDeCursos.Aplicacao.ModuloMatricula.DTOs;

public record ListarMatriculaDto(
    Guid Id,
    string Aluno,
    string Turma,
    DateTime DataMatricula,
    string Situacao
);
