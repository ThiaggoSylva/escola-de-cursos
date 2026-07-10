using EscolaDeCursos.Dominio;

namespace EscolaDeCursos.Aplicacao.Servicos;

public class ServicoCategoria
{
    private readonly IRepositorioCategoria repositorioCategoria;

    public ServicoCategoria(
        IRepositorioCategoria repositorioCategoria)
    {
        this.repositorioCategoria = repositorioCategoria;
    }

    public List<string> Inserir(Categoria categoria)
    {
        List<string> erros = categoria.Validar();

        if (repositorioCategoria.ExisteCategoriaComTitulo(
            categoria.Titulo))
        {
            erros.Add(
                "Já existe uma categoria com este título."
            );
        }

        if (erros.Any())
            return erros;

        repositorioCategoria.Cadastrar(categoria);

        return [];
    }
}
