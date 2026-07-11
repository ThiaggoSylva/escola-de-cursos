using EscolaDeCursos.Dominio;
using EscolaDeCursos.Infra.Compartilhado.Orm;

namespace EscolaDeCursos.Infra.Repositorios;

public class RepositorioModuloOrm : IRepositorioModulo
{
    private readonly EscolaDeCursosDbContext contexto;

    public RepositorioModuloOrm(
        EscolaDeCursosDbContext contexto)
    {
        this.contexto = contexto;
    }

    public void Cadastrar(Modulo entidade)
    {
        contexto.Modulos.Add(entidade);

        contexto.SaveChanges();
    }

    public bool Editar(
        Guid idSelecionado,
        Modulo entidadeAtualizada)
    {
        Modulo? modulo =
            SelecionarPorId(idSelecionado);

        if (modulo is null)
            return false;

        modulo.Atualizar(entidadeAtualizada);

        contexto.SaveChanges();

        return true;
    }

    public bool Excluir(Guid idSelecionado)
    {
        Modulo? modulo =
            SelecionarPorId(idSelecionado);

        if (modulo is null)
            return false;

        contexto.Modulos.Remove(modulo);

        contexto.SaveChanges();

        return true;
    }

    public Modulo? SelecionarPorId(Guid idSelecionado)
    {
        return contexto.Modulos
            .FirstOrDefault(x => x.Id == idSelecionado);
    }

    public List<Modulo> SelecionarTodos()
    {
        return contexto.Modulos
            .OrderBy(x => x.Ordem)
            .ToList();
    }

    public List<Modulo> Filtrar(Func<Modulo, bool> filtro)
    {
        return contexto.Modulos
            .Where(filtro)
            .ToList();
    }

    public bool ExisteOrdemNoCurso(
        Guid cursoId,
        int ordem,
        Guid? idIgnorado = null)
    {
        return contexto.Modulos.Any(x =>
            x.CursoId == cursoId &&
            x.Ordem == ordem &&
            (!idIgnorado.HasValue || x.Id != idIgnorado));
    }

    public List<Modulo> SelecionarPorCurso(
        Guid cursoId)
    {
        return contexto.Modulos
            .Where(x => x.CursoId == cursoId)
            .OrderBy(x => x.Ordem)
            .ToList();
    }
}
