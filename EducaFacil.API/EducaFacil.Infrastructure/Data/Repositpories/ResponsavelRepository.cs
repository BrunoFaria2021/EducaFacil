using EducaFacil.CrossCutting.Extensions;
using EducaFacil.Domain.Entities;
using EducaFacil.Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EducaFacil.Infrastructure.Data.Repositpories
{
    
    public class ResponsavelRepository : IResponsavelRepository
    {
        private readonly ApplicationDbContext _context;

        public ResponsavelRepository(ApplicationDbContext context)
        {
            _context = context;
        }
       

        public RetornoApi<Responsavel> BuscarResponsavelPorId(Guid id, Guid alunoId)
        {
            RetornoApi<Responsavel> retorno = new RetornoApi<Responsavel>()
            {
                Success = false,
                Message = $"Responsável com Id: {id} não encontrado!",
                StatusCode = HttpStatusCode.NotFound
            };

            try
            {
                var responsavel = _context.Responsaveis.Include(x => x.Alunos).Where(x => x.Id == id).FirstOrDefault();
               

                if (responsavel == null)
                {
                    return retorno;
                }

                retorno.Success = true;
                retorno.Message = "Responsável encontrado";
                retorno.StatusCode = HttpStatusCode.OK;
                retorno.Data = responsavel;

                return retorno;
            }
            catch (Exception ex)
            {
                retorno.Errors.Add(ex.ToString());
                retorno.StatusCode = HttpStatusCode.InternalServerError;
                return retorno;
            }
        }
        public RetornoApi<List<Responsavel>> BuscarTodosOsResponsaveis(Guid id)
        {
            RetornoApi<List<Responsavel>> retorno = new RetornoApi<List<Responsavel>>()
            {
                Success = false,
                Message = "Responsáveis não encontrados",
                StatusCode = HttpStatusCode.NotFound
            };

            try
            {
                var responsaveis = _context.Responsaveis.ToList();

                if (responsaveis == null || !responsaveis.Any())
                {
                    return retorno;
                }

                retorno.Success = true;
                retorno.Message = "Responsáveis encontrados";
                retorno.StatusCode = HttpStatusCode.OK;
                retorno.Data = responsaveis;

                return retorno;
            }
            catch (Exception ex)
            {
                retorno.Errors.Add(ex.ToString());
                retorno.StatusCode = HttpStatusCode.InternalServerError;
                return retorno;
            }
        }
        public RetornoApi<Responsavel> CriarResponsavel(Responsavel responsavelContratante)
        {
            RetornoApi<Responsavel> retorno = new RetornoApi<Responsavel>()
            {
                Success = false,
                Message = $"Erro ao criar responsável",
                StatusCode = HttpStatusCode.InternalServerError
            };

            try
            {
                _context.Responsaveis.Add(responsavelContratante);
                _context.SaveChanges();

                retorno.Success = true;
                retorno.Message = "Responsável criado com sucesso";
                retorno.StatusCode = HttpStatusCode.Created;
                retorno.Data = responsavelContratante;

                return retorno;
            }
            catch (Exception ex)
            {
                retorno.Errors.Add(ex.ToString());
                retorno.StatusCode = HttpStatusCode.InternalServerError;
                return retorno;
            }
        }
        public RetornoApi<Responsavel> DeletarResponsavel(Guid id)
        {
            RetornoApi<Responsavel> retorno = new RetornoApi<Responsavel>()
            {
                Success = false,
                Message = "Não foi possível deletar o responsável",
                StatusCode = HttpStatusCode.NotFound
            };

            try
            {
                var responsavel = _context.Responsaveis.Find(id);

                if (responsavel == null)
                {
                    return retorno;
                }

                _context.Responsaveis.Remove(responsavel);
                _context.SaveChanges();

                retorno.Success = true;
                retorno.Message = "Responsável deletado com sucesso";
                retorno.StatusCode = HttpStatusCode.OK;

                return retorno;
            }
            catch (Exception ex)
            {
                retorno.Errors.Add(ex.ToString());
                retorno.StatusCode = HttpStatusCode.InternalServerError;
                return retorno;
            }
        }
        public RetornoApi<Responsavel> EditarResponsavel(Guid id, Responsavel responsavelContratante)
        {
            RetornoApi<Responsavel> retorno = new RetornoApi<Responsavel>()
            {
                Success = false,
                Message = $"Não foi possível atualizar o responsável",
                StatusCode = HttpStatusCode.BadRequest
            };

            try
            {
                var responsavel = _context.Responsaveis.Find(id);

                if (responsavel == null)
                {
                    return retorno;
                }

                responsavel.Nome = responsavelContratante.Nome;
                responsavel.Email = responsavelContratante.Email;
              

                _context.SaveChanges();

                retorno.Success = true;
                retorno.Message = $"Responsável atualizado com sucesso!";
                retorno.StatusCode = HttpStatusCode.OK;

                return retorno;
            }
            catch (Exception ex)
            {
                retorno.Errors.Add(ex.ToString());
                retorno.StatusCode = HttpStatusCode.InternalServerError;
                return retorno;
            }
        }

    }
}
