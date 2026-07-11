using EscolaDeCursos.Dominio;
using EscolaDeCursos.Infra.Compartilhado.Orm;

namespace EscolaDeCursos.Infra.Repositorios;

public class RepositorioAlunoOrm : IRepositorioAluno
{
    private readonly EscolaDeCursosDbContext contexto;

    public RepositorioAlunoOrm(
        EscolaDeCursosDbContext contexto)
    {
        this.contexto = contexto;
    }

    public void Cadastrar(Aluno entidade)
    {
        contexto.Alunos.Add(entidade);

        contexto.SaveChanges();
    }

    public bool Editar(Guid idSelecionado, Aluno entidadeAtualizada)
    {
        Aluno? aluno = SelecionarPorId(idSelecionado);

        if (aluno is null)
            return false;

        aluno.Atualizar(entidadeAtualizada);

        contexto.SaveChanges();

        return true;
    }

    public bool Excluir(Guid idSelecionado)
    {
        Aluno? aluno = SelecionarPorId(idSelecionado);

        if (aluno is null)
            return false;

        contexto.Alunos.Remove(aluno);

        contexto.SaveChanges();

        return true;
    }

    public Aluno? SelecionarPorId(Guid idSelecionado)
    {
        return contexto.Alunos
            .FirstOrDefault(x => x.Id == idSelecionado);
    }

    public List<Aluno> SelecionarTodos()
    {
        return contexto.Alunos
            .OrderBy(x => x.Nome)
            .ToList();
    }

    public List<Aluno> Filtrar(Func<Aluno, bool> filtro)
    {
        return contexto.Alunos
            .Where(filtro)
            .ToList();
    }

    public bool ExisteCpf(string cpf, Guid? idIgnorado = null)
    {
        return contexto.Alunos.Any(x =>
            x.CPF == cpf &&
            (!idIgnorado.HasValue || x.Id != idIgnorado));
    }

    public bool ExisteEmail(string email, Guid? idIgnorado = null)
    {
        return contexto.Alunos.Any(x =>
            x.Email == email &&
            (!idIgnorado.HasValue || x.Id != idIgnorado));
    }

    public bool ExisteTelefone(string telefone, Guid? idIgnorado = null)
    {
        return contexto.Alunos.Any(x =>
            x.Telefone == telefone &&
            (!idIgnorado.HasValue || x.Id != idIgnorado));
    }

    public bool PossuiMatriculasVinculadas(Guid alunoId)
    {
        return contexto.Matriculas
            .Any(x => x.AlunoId == alunoId);
    }
}
