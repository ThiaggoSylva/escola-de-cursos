namespace EscolaDeCursos.Aplicacao.ModuloInstrutor.DTOs;

public record EditarInstrutorDto(
    Guid Id,
    string Nome,
    string Email,
    string Telefone,
    string Especialidade
);
