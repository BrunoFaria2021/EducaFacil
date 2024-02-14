using EducaFacil.CrossCutting.Extensions;
using EducaFacil.Domain.Entities;

namespace EducaFacil.Infrastructure.Data.Interfaces
{
    public interface IAlunoRepository
    {
        RetornoApi<List<Aluno>> BuscarTodosOsAlunos();
        RetornoApi<Aluno> BuscarAluno(Guid id);
        RetornoApi<Aluno> CriarAluno(Aluno alunoDTO);
        RetornoApi<Aluno> EditarAluno(Guid id, Aluno alunoDTO);
        RetornoApi<Aluno> DeletarAluno(Guid id);
    }
}
