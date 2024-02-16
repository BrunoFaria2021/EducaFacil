using EducaFacil.CrossCutting.Extensions;
using EducaFacil.Domain.Entities;

namespace EducaFacil.Infrastructure.Data.Interfaces
{
    public interface ICursoRepository
    {
        RetornoApi<List<Curso>> BuscarTodosOsCursos();
        RetornoApi<Curso> BuscarCurso(Guid id);
        RetornoApi<Curso> CriarCurso(Curso curso);
        RetornoApi<Curso> EditarCurso(Guid id, Curso curso);
        RetornoApi<Curso> DeletarCurso(Guid id);
    }
}
