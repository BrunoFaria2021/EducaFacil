using EducaFacil.CrossCutting.Extensions;
using EducaFacil.Domain.Entities;

namespace EducaFacil.Infrastructure.Data.Interfaces
{
    public interface IResponsavelRepository
    {
        RetornoApi<List<Responsavel>> BuscarTodosOsResponsaveis(Guid id);
        RetornoApi<Responsavel> BuscarResponsavelPorId(Guid id, Guid alunoId);
        RetornoApi<Responsavel> CriarResponsavel(Responsavel responsavelContratante);
        RetornoApi<Responsavel> EditarResponsavel(Guid id, Responsavel responsavelContratante);
        RetornoApi<Responsavel> DeletarResponsavel(Guid id);
    }
}
