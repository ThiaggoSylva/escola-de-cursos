using EscolaDeCursos.Dominio;

namespace EscolaDeCursos.Aplicacao.Servicos;

public class ServicoCategoria
{
    private readonly IRepositorioCategoria repositorioCategoria;

    public ServicoCategoria(
        IRepositorioCategoria repositorioCategoria
    )
    {
        this.repositorioCategoria = repositorioCategoria;
    }
}
