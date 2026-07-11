using EscolaDeCursos.Dominio.Compartilhado;

namespace EscolaDeCursos.Dominio;

public class Instrutor : EntidadeBase<Instrutor>
{
    public string Nome { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Telefone { get; set; } = string.Empty;

    public string Especialidade { get; set; } = string.Empty;

    public ICollection<Turma> Turmas { get; set; }
        = new List<Turma>();

    protected Instrutor() { }

    public Instrutor(
        string nome,
        string email,
        string telefone,
        string especialidade)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Especialidade = especialidade;
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

        if (string.IsNullOrWhiteSpace(Especialidade))
            erros.Add("A especialidade é obrigatória.");

        return erros;
    }

    public override void Atualizar(Instrutor entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        Email = entidadeAtualizada.Email;
        Telefone = entidadeAtualizada.Telefone;
        Especialidade = entidadeAtualizada.Especialidade;
    }
}
