using EscolaDeCursos.Dominio.Compartilhado;

namespace EscolaDeCursos.Dominio;

public class Modulo : EntidadeBase<Modulo>
{
    public string Titulo { get; set; } = string.Empty;

    public int Ordem { get; set; }

    public int DuracaoHoras { get; set; }

    public Guid CursoId { get; set; }

    public Curso? Curso { get; set; }

    protected Modulo() { }

    public Modulo(
        string titulo,
        int ordem,
        int duracaoHoras,
        Guid cursoId)
    {
        Titulo = titulo;
        Ordem = ordem;
        DuracaoHoras = duracaoHoras;
        CursoId = cursoId;
    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (string.IsNullOrWhiteSpace(Titulo))
            erros.Add("O título é obrigatório.");

        if (Titulo.Length < 2 || Titulo.Length > 100)
            erros.Add("O título deve possuir entre 2 e 100 caracteres.");

        if (Ordem <= 0)
            erros.Add("A ordem deve ser maior que zero.");

        if (DuracaoHoras <= 0)
            erros.Add("A duração deve ser maior que zero.");

        if (CursoId == Guid.Empty)
            erros.Add("O curso é obrigatório.");

        return erros;
    }

    public override void Atualizar(Modulo entidadeAtualizada)
    {
        Titulo = entidadeAtualizada.Titulo;
        Ordem = entidadeAtualizada.Ordem;
        DuracaoHoras = entidadeAtualizada.DuracaoHoras;
        CursoId = entidadeAtualizada.CursoId;
    }
}
