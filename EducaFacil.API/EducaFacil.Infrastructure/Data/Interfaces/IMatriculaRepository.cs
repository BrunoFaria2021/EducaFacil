using EducaFacil.CrossCutting.Extensions;
using EducaFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducaFacil.Infrastructure.Data.Interfaces
{
    public interface IMatriculaRepository
    {
        RetornoApi<List<Matricula>> BuscarTodasAsMatriculas(Guid alunoId);
        RetornoApi<Matricula> BuscarMatricula(Guid id);
        RetornoApi<Matricula> CriarMatricula(Matricula matricula);
        RetornoApi<Matricula> EditarMatricula(Guid id, Matricula matricula);
        RetornoApi<Matricula> DeletarMatricula(Guid id);
    }
}
