namespace EscolaDeCursos.Aplicacao.ModuloCurso.DTOs;

public record ListarCursoDto(
    Guid Id,
    string Titulo,
    string Categoria,
    int CargaHoraria,
    string Nivel
);
