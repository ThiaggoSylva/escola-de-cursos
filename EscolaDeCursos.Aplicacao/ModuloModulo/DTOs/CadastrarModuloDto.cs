namespace EscolaDeCursos.Aplicacao.ModuloModulo.DTOs;

public record CadastrarModuloDto(
    string Titulo,
    int Ordem,
    int Duracao,
    Guid CursoId
);
