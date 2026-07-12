namespace EscolaDeCursos.Aplicacao.ModuloInstrutor.DTOs;

public record VisualizarInstrutorDto(
    Guid Id,
    string Nome,
    string Email,
    string Telefone,
    string Especialidade
);
