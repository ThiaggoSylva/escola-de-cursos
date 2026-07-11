using EscolaDeCursos.Dominio;
using EscolaDeCursos.Infra.Compartilhado.Orm;

namespace EscolaDeCursos.Infra.Repositorios;

public class RepositorioInstrutorOrm : IRepositorioInstrutor
{
    private readonly EscolaDeCursosDbContext contexto;

    public RepositorioInstrutorOrm(
        EscolaDeCursosDbContext contexto)
    {
        this.contexto = contexto;
    }

    public void Cadastrar(Instrutor entidade)
    {
        contexto.Instrutores.Add(entidade);

        contexto.SaveChanges();
    }

    public bool Editar(Guid idSelecionado, Instrutor entidadeAtualizada)
    {
        Instrutor? instrutor = SelecionarPorId(idSelecionado);

        if (instrutor is null)
            return false;

        instrutor.Atualizar(entidadeAtualizada);

        contexto.SaveChanges();

        return true;
    }

    public bool Excluir(Guid idSelecionado)
    {
        Instrutor? instrutor = SelecionarPorId(idSelecionado);

        if (instrutor is null)
            return false;

        contexto.Instrutores.Remove(instrutor);

        contexto.SaveChanges();

        return true;
    }

    public Instrutor? SelecionarPorId(Guid idSelecionado)
    {
        return contexto.Instrutores
            .FirstOrDefault(x => x.Id == idSelecionado);
    }

    public List<Instrutor> SelecionarTodos()
    {
        return contexto.Instrutores
            .OrderBy(x => x.Nome)
            .ToList();
    }

    public List<Instrutor> Filtrar(Func<Instrutor, bool> filtro)
    {
        return contexto.Instrutores
            .Where(filtro)
            .ToList();
    }

    public bool ExisteEmail(string email, Guid? idIgnorado = null)
    {
        return contexto.Instrutores.Any(x =>
            x.Email == email &&
            (!idIgnorado.HasValue || x.Id != idIgnorado));
    }

    public bool ExisteTelefone(string telefone, Guid? idIgnorado = null)
    {
        return contexto.Instrutores.Any(x =>
            x.Telefone == telefone &&
            (!idIgnorado.HasValue || x.Id != idIgnorado));
    }

    public bool PossuiTurmasVinculadas(Guid instrutorId)
    {
        return contexto.Turmas
            .Any(x => x.InstrutorId == instrutorId);
    }
}
