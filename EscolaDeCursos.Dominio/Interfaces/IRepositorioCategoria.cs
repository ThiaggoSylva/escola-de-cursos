namespace EscolaDeCursos.Dominio;

public interface IRepositorioCategoria
{
    Categoria? SelecionarPorTitulo(string titulo);

    bool ExisteCategoriaComTitulo(
        string titulo,
        Guid? idIgnorado = null
    );

    bool PossuiCursosVinculados(Guid categoriaId);
}
