using EducaFacil.CrossCutting.Extensions;
using EducaFacil.Domain.Entities;

namespace EducaFacil.Infrastructure.Data.Interfaces
{
    public interface ICursoRepository
    {
        RetornoApi<List<Serie>> BuscarTodosOsCursos();
        RetornoApi<Serie> BuscarCurso(Guid id);
        RetornoApi<Serie> CriarCurso(Serie curso);
        RetornoApi<Serie> EditarCurso(Guid id, Serie curso);
        RetornoApi<Serie> DeletarCurso(Guid id);
    }
}
