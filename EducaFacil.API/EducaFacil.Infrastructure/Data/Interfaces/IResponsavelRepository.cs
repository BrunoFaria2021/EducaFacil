using EducaFacil.CrossCutting.Extensions;
using EducaFacil.Domain.Entities;

namespace EducaFacil.Infrastructure.Data.Interfaces
{
    public interface IResponsavelRepository
    {
        RetornoApi<List<ResponsavelContratante>> BuscarTodosOsResponsaveis(Guid id);
        RetornoApi<ResponsavelContratante> BuscarResponsavelPorId(Guid id, Guid alunoId);
        RetornoApi<ResponsavelContratante> ObterResponsavelPorId(Guid id);
        RetornoApi<ResponsavelContratante> CriarResponsavel(ResponsavelContratante responsavelContratante);
        RetornoApi<ResponsavelContratante> EditarResponsavel(Guid id, ResponsavelContratante responsavelContratante);
        RetornoApi<ResponsavelContratante> DeletarResponsavel(Guid id);
    }
}
