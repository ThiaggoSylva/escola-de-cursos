using EscolaDeCursos.Dominio;
using EscolaDeCursos.Infra.Compartilhado.Orm;

namespace EscolaDeCursos.Infra.Repositorios;

public class RepositorioCursoOrm : IRepositorioCurso
{
    private readonly EscolaDeCursosDbContext contexto;

    public RepositorioCursoOrm(
        EscolaDeCursosDbContext contexto)
    {
        this.contexto = contexto;
    }

    public void Cadastrar(Curso entidade)
    {
        contexto.Cursos.Add(entidade);

        contexto.SaveChanges();
    }

    public bool Editar(
        Guid idSelecionado,
        Curso entidadeAtualizada)
    {
        Curso? curso = SelecionarPorId(idSelecionado);

        if (curso is null)
            return false;

        curso.Atualizar(entidadeAtualizada);

        contexto.SaveChanges();

        return true;
    }

    public bool Excluir(Guid idSelecionado)
    {
        Curso? curso = SelecionarPorId(idSelecionado);

        if (curso is null)
            return false;

        contexto.Cursos.Remove(curso);

        contexto.SaveChanges();

        return true;
    }

    public Curso? SelecionarPorId(Guid idSelecionado)
    {
        return contexto.Cursos
            .FirstOrDefault(x => x.Id == idSelecionado);
    }

    public List<Curso> SelecionarTodos()
    {
        return contexto.Cursos
            .OrderBy(x => x.Titulo)
            .ToList();
    }

    public List<Curso> Filtrar(Func<Curso, bool> filtro)
    {
        return contexto.Cursos
            .Where(filtro)
            .ToList();
    }

    public Curso? SelecionarPorTitulo(
        string titulo,
        Guid categoriaId)
    {
        return contexto.Cursos
            .FirstOrDefault(x =>
                x.Titulo == titulo &&
                x.CategoriaId == categoriaId);
    }

    public bool ExisteCursoComTitulo(
        string titulo,
        Guid categoriaId,
        Guid? idIgnorado = null)
    {
        return contexto.Cursos.Any(x =>
            x.Titulo == titulo &&
            x.CategoriaId == categoriaId &&
            (!idIgnorado.HasValue || x.Id != idIgnorado));
    }

    public bool PossuiTurmasVinculadas(
        Guid cursoId)
    {
        return contexto.Turmas
            .Any(x => x.CursoId == cursoId);
    }
}
