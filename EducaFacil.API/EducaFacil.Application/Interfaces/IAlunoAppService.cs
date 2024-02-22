using EducaFacil.Application.DTOs;
using EducaFacil.Application.ViewModel;
using EducaFacil.CrossCutting.Extensions;

namespace EducaFacil.Application.Interfaces
{
    public interface IAlunoAppService
    {
        Task<RetornoApi<List<AlunoViewModel>>> BuscarTodosOsAlunos(Guid responsavelId);
        Task<RetornoApi<AlunoViewModel>> BuscarAlunoId(Guid id);
        Task<RetornoApi<AlunoViewModel>> CriarAluno(AlunoDTO alunoDTO);// Guid serieId);        
        Task<RetornoApi<AlunoViewModel>> EditarAluno(Guid id, AlunoUpdateDTO alunoDTO);
        Task<RetornoApi<AlunoViewModel>> DeletarAluno(Guid id);
    }
}
