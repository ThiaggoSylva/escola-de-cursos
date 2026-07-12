using AutoMapper;
using EscolaDeCursos.Aplicacao.ModuloInstrutor.DTOs;
using EscolaDeCursos.Dominio;

namespace EscolaDeCursos.Aplicacao.ModuloInstrutor.Mapeamentos;

public class PerfilMapeamentoInstrutor : Profile
{
    public PerfilMapeamentoInstrutor()
    {
        CreateMap<CadastrarInstrutorDto, Instrutor>();

        CreateMap<EditarInstrutorDto, Instrutor>();

        CreateMap<Instrutor, ListarInstrutorDto>();

        CreateMap<Instrutor, VisualizarInstrutorDto>();
    }
}
