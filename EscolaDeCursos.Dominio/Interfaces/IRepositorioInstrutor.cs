using EscolaDeCursos.Dominio.Compartilhado;

namespace EscolaDeCursos.Dominio;

public interface IRepositorioInstrutor
    : IRepositorio<Instrutor>
{
    bool ExisteEmail(
        string email,
        Guid? idIgnorado = null
    );

    bool ExisteTelefone(
        string telefone,
        Guid? idIgnorado = null
    );

    bool PossuiTurmasVinculadas(
        Guid instrutorId
    );
}
