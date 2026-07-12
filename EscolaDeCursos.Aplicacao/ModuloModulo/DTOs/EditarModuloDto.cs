namespace EscolaDeCursos.Aplicacao.ModuloModulo.DTOs;

public record EditarModuloDto(
    Guid Id,
    string Titulo,
    int Ordem,
    int Duracao,
    Guid CursoId
);
