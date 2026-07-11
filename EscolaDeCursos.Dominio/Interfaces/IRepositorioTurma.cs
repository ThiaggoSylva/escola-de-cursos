using EscolaDeCursos.Dominio.Compartilhado;

namespace EscolaDeCursos.Dominio;

public interface IRepositorioTurma
    : IRepositorio<Turma>
{
    bool PossuiMatriculasVinculadas(
        Guid turmaId
    );

    List<Turma> SelecionarPorCurso(
        Guid cursoId
    );

    List<Turma> SelecionarPorInstrutor(
        Guid instrutorId
    );
}
