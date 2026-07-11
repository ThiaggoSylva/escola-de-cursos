using EscolaDeCursos.Dominio.Compartilhado;
using EscolaDeCursos.Dominio.Enumeradores;

namespace EscolaDeCursos.Dominio;

public class Matricula : EntidadeBase<Matricula>
{
    public Guid AlunoId { get; set; }

    public Aluno? Aluno { get; set; }

    public Guid TurmaId { get; set; }

    public Turma? Turma { get; set; }

    public DateTime DataMatricula { get; set; }

    public SituacaoMatricula Situacao { get; set; }

    protected Matricula() { }

    public Matricula(
        Guid alunoId,
        Guid turmaId,
        DateTime dataMatricula,
        SituacaoMatricula situacao)
    {
        AlunoId = alunoId;
        TurmaId = turmaId;
        DataMatricula = dataMatricula;
        Situacao = situacao;
    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (AlunoId == Guid.Empty)
            erros.Add("O aluno é obrigatório.");

        if (TurmaId == Guid.Empty)
            erros.Add("A turma é obrigatória.");

        return erros;
    }

    public override void Atualizar(Matricula entidadeAtualizada)
    {
        AlunoId = entidadeAtualizada.AlunoId;
        TurmaId = entidadeAtualizada.TurmaId;
        DataMatricula = entidadeAtualizada.DataMatricula;
        Situacao = entidadeAtualizada.Situacao;
    }
}
