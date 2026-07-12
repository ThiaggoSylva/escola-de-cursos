using EscolaDeCursos.Dominio.Enumeradores;

namespace EscolaDeCursos.Aplicacao.ModuloMatricula.DTOs;

public record CadastrarMatriculaDto(
    Guid AlunoId,
    Guid TurmaId,
    DateTime DataMatricula,
    SituacaoMatricula Situacao
);
