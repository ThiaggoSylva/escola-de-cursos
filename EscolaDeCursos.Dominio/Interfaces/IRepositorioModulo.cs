using EscolaDeCursos.Dominio.Compartilhado;

namespace EscolaDeCursos.Dominio;

public interface IRepositorioModulo
    : IRepositorio<Modulo>
{
    bool ExisteOrdemNoCurso(
        Guid cursoId,
        int ordem,
        Guid? idIgnorado = null
    );

    List<Modulo> SelecionarPorCurso(
        Guid cursoId
    );
}
