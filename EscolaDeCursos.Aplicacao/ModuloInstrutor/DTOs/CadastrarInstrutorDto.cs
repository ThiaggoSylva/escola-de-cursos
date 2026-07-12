namespace EscolaDeCursos.Aplicacao.ModuloInstrutor.DTOs;

public record CadastrarInstrutorDto(
    string Nome,
    string Email,
    string Telefone,
    string Especialidade
);
