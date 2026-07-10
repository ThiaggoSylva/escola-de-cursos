using EscolaDeCursos.Dominio;
using EscolaDeCursos.Infra.Compartilhado.Orm;

namespace EscolaDeCursos.Infra.Repositorios;

public class RepositorioCategoriaOrm
    : IRepositorioCategoria
{
    private readonly EscolaDeCursosDbContext contexto;

    public RepositorioCategoriaOrm(
        EscolaDeCursosDbContext contexto)
    {
        this.contexto = contexto;
    }

    public void Cadastrar(Categoria entidade)
    {
        contexto.Categorias.Add(entidade);

        contexto.SaveChanges();
    }

    public bool Editar(
        Guid idSelecionado,
        Categoria entidadeAtualizada)
    {
        Categoria? categoria =
            SelecionarPorId(idSelecionado);

        if (categoria is null)
            return false;

        categoria.Atualizar(entidadeAtualizada);

        contexto.SaveChanges();

        return true;
    }

    public bool Excluir(Guid idSelecionado)
    {
        Categoria? categoria =
            SelecionarPorId(idSelecionado);

        if (categoria is null)
            return false;

        contexto.Categorias.Remove(categoria);

        contexto.SaveChanges();

        return true;
    }

    public Categoria? SelecionarPorId(Guid idSelecionado)
    {
        return contexto.Categorias
            .FirstOrDefault(x => x.Id == idSelecionado);
    }

    public List<Categoria> SelecionarTodos()
    {
        return contexto.Categorias
            .OrderBy(x => x.Titulo)
            .ToList();
    }

    public List<Categoria> Filtrar(Func<Categoria, bool> filtro)
    {
        return contexto.Categorias
            .Where(filtro)
            .ToList();
    }

    public Categoria? SelecionarPorTitulo(string titulo)
    {
        return contexto.Categorias
            .FirstOrDefault(x => x.Titulo == titulo);
    }

    public bool ExisteCategoriaComTitulo(
        string titulo,
        Guid? idIgnorado = null)
    {
        return contexto.Categorias.Any(x =>
            x.Titulo == titulo &&
            (!idIgnorado.HasValue || x.Id != idIgnorado));
    }

    public bool PossuiCursosVinculados(Guid categoriaId)
    {
        return contexto.Set<Curso>()
            .Any(x => x.CategoriaId == categoriaId);
    }
}
