using EscolaDeCursos.Dominio.Compartilhado;

namespace EscolaDeCursos.Dominio;

public interface IRepositorioCurso
    : IRepositorio<Curso>
{
    Curso? SelecionarPorTitulo(
        string titulo,
        Guid categoriaId
    );

    bool ExisteCursoComTitulo(
        string titulo,
        Guid categoriaId,
        Guid? idIgnorado = null
    );

    bool PossuiTurmasVinculadas(
        Guid cursoId
    );
}
