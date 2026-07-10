using EscolaDeCursos.Dominio.Compartilhado;

namespace EscolaDeCursos.Dominio;

public class Categoria : EntidadeBase<Categoria>
{
    public string Titulo { get; set; } = string.Empty;

    protected Categoria() { }

    public Categoria(string titulo)
    {
        Titulo = titulo;
    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (string.IsNullOrWhiteSpace(Titulo))
            erros.Add("O título é obrigatório.");

        if (Titulo.Length < 2 || Titulo.Length > 100)
            erros.Add("O título deve conter entre 2 e 100 caracteres.");

        return erros;
    }

    public override void Atualizar(Categoria registroAtualizado)
    {
        Titulo = registroAtualizado.Titulo;
    }

    public override string ToString()
    {
        return Titulo;
    }
}
