using AutoMapper;
using EscolaDeCursos.Aplicacao.ModuloCurso.DTOs;
using EscolaDeCursos.ModuloCurso.Apresentacao.Models;

namespace EscolaDeCursos.ModuloCurso.Apresentacao.Mapeamentos;

public class PerfilMapeamentoCursoViewModel : Profile
{
    public PerfilMapeamentoCursoViewModel()
    {
        CreateMap<CadastrarCursoViewModel, CadastrarCursoDto>();

        CreateMap<EditarCursoViewModel, EditarCursoDto>();

        CreateMap<VisualizarCursoDto, EditarCursoViewModel>();

        CreateMap<VisualizarCursoDto, ExcluirCursoViewModel>();

        CreateMap<ListarCursoDto, ListarCursoViewModel>();

        CreateMap<VisualizarCursoDto, VisualizarCursoViewModel>();
    }
}
