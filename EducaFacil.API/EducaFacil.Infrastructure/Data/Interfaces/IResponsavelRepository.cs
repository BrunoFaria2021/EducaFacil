using EducaFacil.CrossCutting.Extensions;
using EducaFacil.Domain.Entities;

namespace EducaFacil.Infrastructure.Data.Interfaces
{
    public interface IResponsavelRepository
    {
        RetornoApi<List<ResponsavelContratante>> BuscarTodosOsResponsaveis();
        RetornoApi<ResponsavelContratante> BuscarResponsavel(Guid id);
        RetornoApi<ResponsavelContratante> CriarResponsavel(ResponsavelContratante responsavelContratante);
        RetornoApi<ResponsavelContratante> EditarResponsavel(Guid id, ResponsavelContratante responsavelContratante);
        RetornoApi<ResponsavelContratante> DeletarResponsavel(Guid id);
    }
}
