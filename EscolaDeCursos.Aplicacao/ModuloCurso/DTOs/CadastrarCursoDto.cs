using EscolaDeCursos.Dominio.Enumeradores;

namespace EscolaDeCursos.Aplicacao.ModuloCurso.DTOs;

public record CadastrarCursoDto(
    string Titulo,
    string Descricao,
    int CargaHoraria,
    NivelCurso Nivel,
    Guid CategoriaId
);
