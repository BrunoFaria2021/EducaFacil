using EducaFacil.CrossCutting.Extensions;
using EducaFacil.Domain.Entities;

namespace EducaFacil.Infrastructure.Data.Interfaces
{
    public interface IDisciplinaRepository
    {
        RetornoApi<List<Materia>> BuscarTodasAsDisciplinas();
        RetornoApi<Materia> BuscarDisciplina(Guid id);
        RetornoApi<Materia> CriarDisciplina(Materia disciplina);
        RetornoApi<Materia> EditarDisciplina(Guid id, Materia disciplina);
        RetornoApi<Materia> DeletarDisciplina(Guid id);
    }
}
