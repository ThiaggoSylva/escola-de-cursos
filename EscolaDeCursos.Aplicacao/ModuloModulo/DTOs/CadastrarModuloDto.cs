namespace EscolaDeCursos.Aplicacao.ModuloModulo.DTOs;

public record CadastrarModuloDto(
    string Titulo,
    int Ordem,
    int DuracaoHoras,
    Guid CursoId
);
