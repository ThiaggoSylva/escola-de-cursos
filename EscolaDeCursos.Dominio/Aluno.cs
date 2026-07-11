using EscolaDeCursos.Dominio.Compartilhado;

namespace EscolaDeCursos.Dominio;

public class Aluno : EntidadeBase<Aluno>
{
    public string Nome { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Telefone { get; set; } = string.Empty;

    public string CPF { get; set; } = string.Empty;

    public ICollection<Matricula> Matriculas { get; set; }
        = new List<Matricula>();

    protected Aluno() { }

    public Aluno(
        string nome,
        string email,
        string telefone,
        string cpf)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        CPF = cpf;
    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (string.IsNullOrWhiteSpace(Nome))
            erros.Add("O nome é obrigatório.");

        if (Nome.Length < 2 || Nome.Length > 100)
            erros.Add("O nome deve conter entre 2 e 100 caracteres.");

        if (string.IsNullOrWhiteSpace(Email))
            erros.Add("O e-mail é obrigatório.");

        if (string.IsNullOrWhiteSpace(Telefone))
            erros.Add("O telefone é obrigatório.");

        if (string.IsNullOrWhiteSpace(CPF))
            erros.Add("O CPF é obrigatório.");

        return erros;
    }

    public override void Atualizar(Aluno entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        Email = entidadeAtualizada.Email;
        Telefone = entidadeAtualizada.Telefone;
        CPF = entidadeAtualizada.CPF;
    }
}
