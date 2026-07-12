namespace EscolaDeCursos.Aplicacao.ModuloModulo.DTOs;

public record ListarModuloDto(
    Guid Id,
    string Titulo,
    int Ordem,
    int Duracao,
    string Curso
);
