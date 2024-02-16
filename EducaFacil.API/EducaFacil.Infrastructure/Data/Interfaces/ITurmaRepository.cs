using EducaFacil.CrossCutting.Extensions;
using EducaFacil.Domain.Entities;

namespace EducaFacil.Infrastructure.Data.Interfaces
{
    public interface ITurmaRepository
    {
        RetornoApi<List<Turma>> BuscarTodasAsTurmas();
        RetornoApi<Turma> BuscarTurma(Guid id);
        RetornoApi<Turma> CriarTurma(Turma turma);
        RetornoApi<Turma> EditarTurma(Guid id, Turma turma);
        RetornoApi<Turma> DeletarTurma(Guid id);
    }
}
