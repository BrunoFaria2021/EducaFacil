using EducaFacil.Application.DTOs;
using EducaFacil.Application.ViewModel;
using EducaFacil.CrossCutting.Extensions;

namespace EducaFacil.Application.Interfaces
{
    public interface IMatriculaAppService
    {
        Task<RetornoApi<MatriculaViewModel>> MatricularAluno(MatriculaDTO matriculaDTO);
        Task<RetornoApi<MatriculaViewModel>> ObterMatriculaPorId(Guid id);
        Task<RetornoApi<MatriculaViewModel>> CancelarMatricula(Guid id);

    }
}
