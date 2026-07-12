namespace EscolaDeCursos.Aplicacao.ModuloAluno.DTOs;

public record EditarAlunoDto(
    Guid Id,
    string Nome,
    string Email,
    string Telefone,
    string CPF
);
