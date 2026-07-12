using AutoMapper;
using EscolaDeCursos.Aplicacao.ModuloAluno.DTOs;
using EscolaDeCursos.Dominio;

namespace EscolaDeCursos.Aplicacao.ModuloAluno.Mapeamentos;

public class PerfilMapeamentoAluno : Profile
{
    public PerfilMapeamentoAluno()
    {
        CreateMap<CadastrarAlunoDto, Aluno>();

        CreateMap<EditarAlunoDto, Aluno>();

        CreateMap<Aluno, ListarAlunoDto>();

        CreateMap<Aluno, VisualizarAlunoDto>();
    }
}
