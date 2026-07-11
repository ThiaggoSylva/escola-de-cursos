using EscolaDeCursos.Dominio.Compartilhado;

namespace EscolaDeCursos.Dominio;

public interface IRepositorioMatricula
    : IRepositorio<Matricula>
{
    bool AlunoJaMatriculado(
        Guid alunoId,
        Guid turmaId,
        Guid? idIgnorado = null
    );

    List<Matricula> SelecionarPorAluno(
        Guid alunoId
    );

    List<Matricula> SelecionarPorTurma(
        Guid turmaId
    );
}
