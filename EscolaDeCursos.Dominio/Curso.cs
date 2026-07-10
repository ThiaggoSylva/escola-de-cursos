using EscolaDeCursos.Dominio.Compartilhado;
using EscolaDeCursos.Dominio.Enumeradores;

namespace EscolaDeCursos.Dominio;

public class Curso : EntidadeBase<Curso>
{
    public string Titulo { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public int CargaHoraria { get; set; }

    public NivelCurso Nivel { get; set; }

    public Guid CategoriaId { get; set; }

    public Categoria? Categoria { get; set; }

    public ICollection<Modulo> Modulos { get; set; }
        = new List<Modulo>();

    public ICollection<Turma> Turmas { get; set; }
        = new List<Turma>();

    protected Curso() { }

    public Curso(
        string titulo,
        string descricao,
        int cargaHoraria,
        NivelCurso nivel,
        Guid categoriaId)
    {
        Titulo = titulo;
        Descricao = descricao;
        CargaHoraria = cargaHoraria;
        Nivel = nivel;
        CategoriaId = categoriaId;
    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (string.IsNullOrWhiteSpace(Titulo))
            erros.Add("O título é obrigatório.");

        if (Titulo.Length < 2 || Titulo.Length > 100)
            erros.Add("O título deve possuir entre 2 e 100 caracteres.");

        if (string.IsNullOrWhiteSpace(Descricao))
            erros.Add("A descrição é obrigatória.");

        if (CargaHoraria <= 0)
            erros.Add("A carga horária deve ser maior que zero.");

        if (CategoriaId == Guid.Empty)
            erros.Add("A categoria é obrigatória.");

        return erros;
    }

    public override void Atualizar(Curso entidadeAtualizada)
    {
        Titulo = entidadeAtualizada.Titulo;
        Descricao = entidadeAtualizada.Descricao;
        CargaHoraria = entidadeAtualizada.CargaHoraria;
        Nivel = entidadeAtualizada.Nivel;
        CategoriaId = entidadeAtualizada.CategoriaId;
    }
}
