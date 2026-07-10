using EscolaDeCursos.Dominio.Compartilhado;

namespace EscolaDeCursos.Dominio;

public interface IRepositorioCategoria
    : IRepositorio<Categoria>
{
    Categoria? SelecionarPorTitulo(string titulo);

    bool ExisteCategoriaComTitulo(string titulo);
}
