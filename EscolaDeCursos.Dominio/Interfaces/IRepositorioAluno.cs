using EscolaDeCursos.Dominio.Compartilhado;

namespace EscolaDeCursos.Dominio;

public interface IRepositorioAluno
    : IRepositorio<Aluno>
{
    bool ExisteCpf(
        string cpf,
        Guid? idIgnorado = null
    );

    bool ExisteEmail(
        string email,
        Guid? idIgnorado = null
    );

    bool ExisteTelefone(
        string telefone,
        Guid? idIgnorado = null
    );

    bool PossuiMatriculasVinculadas(
        Guid alunoId
    );
}
