using EscolaDeCursos.Dominio.Enumeradores;

namespace EscolaDeCursos.Aplicacao.ModuloMatricula.DTOs;

public record EditarMatriculaDto(
    Guid Id,
    Guid AlunoId,
    Guid TurmaId,
    DateTime DataMatricula,
    SituacaoMatricula Situacao
);
