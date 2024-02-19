using EducaFacil.CrossCutting.Extensions;
using EducaFacil.Domain.Entities;
using EducaFacil.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EducaFacil.Infrastructure.Data.Repositpories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly ApplicationDbContext _context;

        public MatriculaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public RetornoApi<Matricula> ObterMatriculaPorId(Guid id)
        {
            RetornoApi<Matricula> retorno = new RetornoApi<Matricula>()
            {
                Success = false,
                Message = $"Matricula com Id: {id} não encontrado!",
                StatusCode = HttpStatusCode.NotFound
            };
            try
            {
                var matricula = _context.Matriculas.FirstOrDefault(x => x.Id == id);

                if (matricula == null)
                {
                    retorno.Success = true;
                    retorno.Data = matricula;
                    retorno.StatusCode = HttpStatusCode.NotFound;
                    return retorno;
                }
                retorno.Success = true;

                retorno.Message = "Matricula encontrada";
                retorno.StatusCode = HttpStatusCode.OK;
                retorno.Data = matricula;
                return retorno;

            }
            catch (Exception ex)
            {
                retorno.Errors.Add($"{ex.Message}");
                return retorno;
            }
        }

        public RetornoApi<Matricula> MatricularAluno(Matricula matriculaDTO)
        {
            RetornoApi<Matricula> retorno = new RetornoApi<Matricula>()
            {
                Success = false,
                Message = $"Não foi possível matricular o aluno!",
                StatusCode = HttpStatusCode.BadRequest
            };
            try
            {
                _context.Matriculas.Add(matriculaDTO);
                var resultado = _context.SaveChanges();

                if (resultado >= 1)
                {
                    retorno.Message = "Aluno matriculado com sucesso";
                    retorno.StatusCode = HttpStatusCode.OK;
                    retorno.Success = true;

                    return retorno;
                }

                return retorno;
            }
            catch (Exception ex)
            {
                retorno.Errors.Add($"{ex.InnerException}");
                retorno.StatusCode = HttpStatusCode.InternalServerError;
                return retorno;
            }
        }

        public RetornoApi<Matricula> CancelarMatricula(Guid id)
        {
            RetornoApi<Matricula> retorno = new RetornoApi<Matricula>()
            {
                Success = false,
                Message = $"Não foi possível cancelar a matricula!",
                StatusCode = HttpStatusCode.NotFound
            };
            try
            {
                var matricula = _context.Matriculas.SingleOrDefault(x => x.Id == id);

                if (matricula == null)
                {
                    retorno.Message = $"Matricula não encontrada!";
                    return retorno;
                }

                _context.Matriculas.Remove(matricula);
                _context.SaveChanges();

                retorno.Success = true;
                retorno.Message = $"Matricula cancelada com sucesso!";
                retorno.StatusCode = HttpStatusCode.OK;

                return retorno;
            }
            catch (Exception ex)
            {
                retorno.Errors.Add($"{ex.InnerException}");
                retorno.StatusCode = HttpStatusCode.InternalServerError;
                return retorno;
            }
        }
    }
}
