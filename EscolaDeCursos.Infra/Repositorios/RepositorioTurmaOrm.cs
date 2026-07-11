using EscolaDeCursos.Dominio;
using EscolaDeCursos.Infra.Compartilhado.Orm;

namespace EscolaDeCursos.Infra.Repositorios;

public class RepositorioTurmaOrm : IRepositorioTurma
{
    private readonly EscolaDeCursosDbContext contexto;

    public RepositorioTurmaOrm(
        EscolaDeCursosDbContext contexto)
    {
        this.contexto = contexto;
    }

    public void Cadastrar(Turma entidade)
    {
        contexto.Turmas.Add(entidade);

        contexto.SaveChanges();
    }

    public bool Editar(Guid idSelecionado, Turma entidadeAtualizada)
    {
        Turma? turma = SelecionarPorId(idSelecionado);

        if (turma is null)
            return false;

        turma.Atualizar(entidadeAtualizada);

        contexto.SaveChanges();

        return true;
    }

    public bool Excluir(Guid idSelecionado)
    {
        Turma? turma = SelecionarPorId(idSelecionado);

        if (turma is null)
            return false;

        contexto.Turmas.Remove(turma);

        contexto.SaveChanges();

        return true;
    }

    public Turma? SelecionarPorId(Guid idSelecionado)
    {
        return contexto.Turmas
            .FirstOrDefault(x => x.Id == idSelecionado);
    }

    public List<Turma> SelecionarTodos()
    {
        return contexto.Turmas
            .OrderBy(x => x.Nome)
            .ToList();
    }

    public List<Turma> Filtrar(Func<Turma, bool> filtro)
    {
        return contexto.Turmas
            .Where(filtro)
            .ToList();
    }

    public bool PossuiMatriculasVinculadas(Guid turmaId)
    {
        return contexto.Matriculas
            .Any(x => x.TurmaId == turmaId);
    }

    public List<Turma> SelecionarPorCurso(Guid cursoId)
    {
        return contexto.Turmas
            .Where(x => x.CursoId == cursoId)
            .ToList();
    }

    public List<Turma> SelecionarPorInstrutor(Guid instrutorId)
    {
        return contexto.Turmas
            .Where(x => x.InstrutorId == instrutorId)
            .ToList();
    }
}
