using EscolaDeCursos.Dominio.Compartilhado;

namespace EscolaDeCursos.Dominio;

public class Turma : EntidadeBase<Turma>
{
    public string Nome { get; set; } = string.Empty;

    public Guid CursoId { get; set; }

    public Curso? Curso { get; set; }

    public Guid InstrutorId { get; set; }

    public Instrutor? Instrutor { get; set; }

    public DateTime DataInicio { get; set; }

    public DateTime DataTermino { get; set; }

    public int CapacidadeMaxima { get; set; }

    public ICollection<Matricula> Matriculas { get; set; }
        = new List<Matricula>();

    protected Turma() { }

    public Turma(
        string nome,
        Guid cursoId,
        Guid instrutorId,
        DateTime dataInicio,
        DateTime dataTermino,
        int capacidadeMaxima)
    {
        Nome = nome;
        CursoId = cursoId;
        InstrutorId = instrutorId;
        DataInicio = dataInicio;
        DataTermino = dataTermino;
        CapacidadeMaxima = capacidadeMaxima;
    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (string.IsNullOrWhiteSpace(Nome))
            erros.Add("O nome da turma é obrigatório.");

        if (CursoId == Guid.Empty)
            erros.Add("O curso é obrigatório.");

        if (InstrutorId == Guid.Empty)
            erros.Add("O instrutor é obrigatório.");

        if (DataTermino <= DataInicio)
            erros.Add("A data de término deve ser posterior à data de início.");

        if (CapacidadeMaxima <= 0)
            erros.Add("A capacidade máxima deve ser maior que zero.");

        return erros;
    }

    public override void Atualizar(Turma entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        CursoId = entidadeAtualizada.CursoId;
        InstrutorId = entidadeAtualizada.InstrutorId;
        DataInicio = entidadeAtualizada.DataInicio;
        DataTermino = entidadeAtualizada.DataTermino;
        CapacidadeMaxima = entidadeAtualizada.CapacidadeMaxima;
    }
}
