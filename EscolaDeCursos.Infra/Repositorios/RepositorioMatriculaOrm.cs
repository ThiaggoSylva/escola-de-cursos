using EscolaDeCursos.Dominio;
using EscolaDeCursos.Infra.Compartilhado.Orm;

namespace EscolaDeCursos.Infra.Repositorios;

public class RepositorioMatriculaOrm : IRepositorioMatricula
{
    private readonly EscolaDeCursosDbContext contexto;

    public RepositorioMatriculaOrm(
        EscolaDeCursosDbContext contexto)
    {
        this.contexto = contexto;
    }

    public void Cadastrar(Matricula entidade)
    {
        contexto.Matriculas.Add(entidade);

        contexto.SaveChanges();
    }

    public bool Editar(Guid idSelecionado, Matricula entidadeAtualizada)
    {
        Matricula? matricula = SelecionarPorId(idSelecionado);

        if (matricula is null)
            return false;

        matricula.Atualizar(entidadeAtualizada);

        contexto.SaveChanges();

        return true;
    }

    public bool Excluir(Guid idSelecionado)
    {
        Matricula? matricula = SelecionarPorId(idSelecionado);

        if (matricula is null)
            return false;

        contexto.Matriculas.Remove(matricula);

        contexto.SaveChanges();

        return true;
    }

    public Matricula? SelecionarPorId(Guid idSelecionado)
    {
        return contexto.Matriculas
            .FirstOrDefault(x => x.Id == idSelecionado);
    }

    public List<Matricula> SelecionarTodos()
    {
        return contexto.Matriculas
            .OrderByDescending(x => x.DataMatricula)
            .ToList();
    }

    public List<Matricula> Filtrar(Func<Matricula, bool> filtro)
    {
        return contexto.Matriculas
            .Where(filtro)
            .ToList();
    }

    public bool AlunoJaMatriculado(
        Guid alunoId,
        Guid turmaId,
        Guid? idIgnorado = null)
    {
        return contexto.Matriculas.Any(x =>
            x.AlunoId == alunoId &&
            x.TurmaId == turmaId &&
            (!idIgnorado.HasValue || x.Id != idIgnorado));
    }

    public List<Matricula> SelecionarPorAluno(Guid alunoId)
    {
        return contexto.Matriculas
            .Where(x => x.AlunoId == alunoId)
            .ToList();
    }

    public List<Matricula> SelecionarPorTurma(Guid turmaId)
    {
        return contexto.Matriculas
            .Where(x => x.TurmaId == turmaId)
            .ToList();
    }
}
