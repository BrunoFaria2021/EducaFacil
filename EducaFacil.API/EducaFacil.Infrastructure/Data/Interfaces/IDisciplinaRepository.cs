using EducaFacil.CrossCutting.Extensions;
using EducaFacil.Domain.Entities;

namespace EducaFacil.Infrastructure.Data.Interfaces
{
    public interface IDisciplinaRepository
    {
        RetornoApi<List<Disciplina>> BuscarTodasAsDisciplinas();
        RetornoApi<Disciplina> BuscarDisciplina(Guid id);
        RetornoApi<Disciplina> CriarDisciplina(Disciplina disciplina);
        RetornoApi<Disciplina> EditarDisciplina(Guid id, Disciplina disciplina);
        RetornoApi<Disciplina> DeletarDisciplina(Guid id);
    }
}
