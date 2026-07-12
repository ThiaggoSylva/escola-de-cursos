namespace EscolaDeCursos.Aplicacao.ModuloAluno.DTOs;

public record ListarAlunoDto(
    Guid Id,
    string Nome,
    string Email,
    string Telefone,
    string CPF
);
