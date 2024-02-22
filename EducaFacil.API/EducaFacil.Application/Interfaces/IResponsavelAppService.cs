using EducaFacil.Application.DTOs;
using EducaFacil.Application.ViewModel;
using EducaFacil.CrossCutting.Extensions;

namespace EducaFacil.Application.Interfaces
{
    public interface IResponsavelAppService
    {
        Task<RetornoApi<ResponsavelViewModel>> BuscarResponsavelPorId(Guid id, Guid alunoId);
        Task<RetornoApi<List<ResponsavelViewModel>>> BuscarTodosOsResponsaveis(Guid id);
        Task<RetornoApi<ResponsavelViewModel>> CriarResponsavel(ResponsavelContratanteDTO responsavelDTO);
        Task<RetornoApi<ResponsavelViewModel>> EditarResponsavel(Guid id, ResponsavelUpdateDTO responsavelDTO);
        Task<RetornoApi<ResponsavelViewModel>> DeletarResponsavel(Guid id);
    }
}
