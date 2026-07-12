namespace EscolaDeCursos.Aplicacao.ModuloInstrutor.DTOs;

public record ListarInstrutorDto(
    Guid Id,
    string Nome,
    string Email,
    string Telefone,
    string Especialidade
);
