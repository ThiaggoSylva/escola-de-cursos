using EscolaDeCursos.Dominio.Enumeradores;

namespace EscolaDeCursos.Aplicacao.ModuloCurso.DTOs;

public record EditarCursoDto(
    Guid Id,
    string Titulo,
    string Descricao,
    int CargaHoraria,
    NivelCurso Nivel,
    Guid CategoriaId
);
