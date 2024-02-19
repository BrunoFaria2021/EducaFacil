using EducaFacil.CrossCutting.Extensions;
using EducaFacil.Domain.Entities;
using EducaFacil.Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EducaFacil.Infrastructure.Data.Repositpories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly ApplicationDbContext _context;

        public AlunoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public RetornoApi<Aluno> BuscarAlunoId(Guid id)
        {
            RetornoApi<Aluno> retorno = new RetornoApi<Aluno>()
            {
                Success = false,
                Message = $"Alunos com Id: {id} não encontrado!",
                StatusCode = HttpStatusCode.NotFound
            };
            try
            {
                var buscarAlunoId = _context.Alunos.FirstOrDefault(x => x.Id == id);
                //var buscarAlunoId = _context.Alunos.Include(x => x.ResponsavelId).Where(x => x.Id == id).FirstOrDefault();

                if (buscarAlunoId == null)
                {
                    retorno.Success = true;
                    retorno.Data = buscarAlunoId;
                    retorno.StatusCode = HttpStatusCode.NotFound;
                    return retorno;
                }
                retorno.Success = true;

                retorno.Message = "Chat encontrado";
                retorno.StatusCode = HttpStatusCode.OK;
                retorno.Data = buscarAlunoId;
                return retorno;


            }
            catch (Exception ex)
            {

                retorno.Errors.Add($"{ex}");

                return retorno;

            }
        }

        public RetornoApi<List<Aluno>> BuscarTodosOsAlunos(Guid responsavelId)
        {
            var retorno = new RetornoApi<List<Aluno>>
            {
                Success = false,
                StatusCode = HttpStatusCode.NotFound,
                Message = "Alunos não encontrados."
            };

            try
            {
                var alunos = _context.Alunos.Where(a => a.ResponsavelId == responsavelId).ToList();

                if (alunos.Any())
                {
                    retorno.Success = true;
                    retorno.StatusCode = HttpStatusCode.OK;
                    retorno.Message = "Alunos encontrados com sucesso.";
                    retorno.Data = alunos;
                }

                return retorno;
            }
            catch (Exception ex)
            {
                retorno.Errors.Add(ex.Message);
                retorno.StatusCode = HttpStatusCode.InternalServerError;
                return retorno;
            }
        }

        public RetornoApi<Aluno> CriarAluno(Aluno alunoDTO, Guid serieId)
        {
            RetornoApi<Aluno> retorno = new RetornoApi<Aluno>()
            {
                Success = false,
                Message = $"Alunos Crie",
                StatusCode = HttpStatusCode.NotFound
            };
            try
            {
                _context.Alunos.Add(alunoDTO);
                var resultado = _context.SaveChanges();

                if (resultado >= 1)
                {
                    retorno.Message = "Aluno criado com sucesso";
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
            throw new NotImplementedException();
        }

        public RetornoApi<Aluno> DeletarAluno(Guid id)
        {

            RetornoApi<Aluno> retorno = new RetornoApi<Aluno>()
            {
                Message = "não foi possivel deletar o Aluno",
                Success = false,
                StatusCode = HttpStatusCode.NotFound
            };
            try
            {
                var paciente = _context.Alunos.SingleOrDefault(x => x.Id == id && x.Id == id);

                if (paciente == null)
                {
                    retorno.Message = $"Aluno não encontrado!";
                    return retorno;
                }

                _context.Alunos.Remove(paciente);
                _context.SaveChanges();

                retorno.Success = true;
                retorno.Message = $"Akuno deletado com sucesso!";
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

        public RetornoApi<Aluno> EditarAluno(Guid id, Aluno alunoDTO)
        {
            RetornoApi<Aluno> retorno = new RetornoApi<Aluno>()
            {
                Success = false,
                Message = $"Não foi possível atualizar o status do Aluno!",
                StatusCode = HttpStatusCode.BadRequest
            };
            try
            {


                var aluno = _context.Alunos.SingleOrDefault(x => x.Id == id);
                var alunoAtualziado = aluno;
                if (aluno.Nome != alunoDTO.Nome) alunoAtualziado.Nome = alunoDTO.Nome;
                _context.Entry(aluno).CurrentValues.SetValues(alunoAtualziado);

                _context.SaveChanges();
                retorno.Success = true;
                retorno.Message = $"Aluno Atualizado com sucesso!";
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
