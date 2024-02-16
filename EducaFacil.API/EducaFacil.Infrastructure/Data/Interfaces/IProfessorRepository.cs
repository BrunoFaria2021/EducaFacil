using EducaFacil.CrossCutting.Extensions;
using EducaFacil.Domain.Entities;

namespace EducaFacil.Infrastructure.Data.Interfaces
{
    public interface IProfessorRepository
    {
        RetornoApi<List<Professor>> BuscarTodosOsProfessores(Guid turmaId);
        RetornoApi<Professor> BuscarProfessor(Guid id);
        RetornoApi<Professor> CriarProfessor(Professor professor);
        RetornoApi<Professor> EditarProfessor(Guid id, Professor professor);
        RetornoApi<Professor> DeletarProfessor(Guid id);
    }
}
