namespace EscolaDeCursos.Aplicacao.ModuloAluno.DTOs;

public record CadastrarAlunoDto(
    string Nome,
    string Email,
    string Telefone,
    string CPF
);
