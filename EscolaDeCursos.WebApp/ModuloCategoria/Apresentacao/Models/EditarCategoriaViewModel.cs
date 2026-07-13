using System.ComponentModel.DataAnnotations;

namespace EscolaDeCursos.ModuloCategoria.Apresentacao.Models;

public class EditarCategoriaViewModel
    : FormularioCategoriaViewModel
{
    public Guid Id { get; set; }
}
