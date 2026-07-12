namespace EscolaDeCursos.Aplicacao.ModuloAluno.DTOs;

public record VisualizarAlunoDto(
    Guid Id,
    string Nome,
    string Email,
    string Telefone,
    string CPF
);
