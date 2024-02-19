using EducaFacil.CrossCutting.Extensions;
using EducaFacil.Domain.Entities;

namespace EducaFacil.Infrastructure.Data.Interfaces
{
    public interface IMatriculaRepository
    {

       // RetornoApi<Matricula> BuscarMatricula(Guid id);
        RetornoApi<Matricula> ObterMatriculaPorId(Guid id);
        RetornoApi<Matricula> MatricularAluno(Matricula matriculaDTO);
        RetornoApi<Matricula> CancelarMatricula(Guid id);
    }
}
