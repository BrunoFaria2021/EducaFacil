using EducaFacil.CrossCutting.Extensions;
using EducaFacil.Domain.Entities;
using EducaFacil.Infrastructure.Data.Interfaces;
using System.Net;

namespace EducaFacil.Infrastructure.Data.Repositpories
{
    public class AutenticacaoRepository : IAutenticacaoRepository
    {
        private readonly ApplicationDbContext _context;

        public AutenticacaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public RetornoApi<dynamic> BuscarUsuarioPorEmail(string login)
        {

            RetornoApi<dynamic> retorno = new RetornoApi<dynamic>()
            {
            };

            try
            {

                retorno.StatusCode = HttpStatusCode.OK;
                retorno.Success = true;

                var alunos = _context.Alunos.FirstOrDefault(p => p.Email == login);

                if (alunos != null)
                {

                    retorno.Data = alunos;
                    return retorno;

                }

                var responsaveis = _context.Responsaveis.FirstOrDefault(p => p.Email == login);

                if (responsaveis != null)
                {

                    retorno.Data = responsaveis;
                    return retorno;
                }

                var professor = _context.Professores.FirstOrDefault(p => p.Email == login);


                if (professor != null)
                {
                    retorno.Data = professor;
                    return retorno;
                }

                retorno.StatusCode = HttpStatusCode.NotFound;
                retorno.Success = false;

                return retorno;
            }
            catch (Exception ex)
            {

                retorno.Errors.Add($"{ex.InnerException}");

                return retorno;
            }
        }

        public RetornoApi<RefreshToken> BuscarRefreshToken(Guid usuarioId)
        {

            RetornoApi<RefreshToken> retorno = new RetornoApi<RefreshToken>()
            {
            };

            try
            {

                retorno.StatusCode = HttpStatusCode.OK;
                retorno.Success = true;

                var refreshToken = _context.RefreshToken.FirstOrDefault(r => r.UsuarioId == usuarioId);


                if (refreshToken != null)
                {
                    retorno.Data = refreshToken;
                    return retorno;
                }

                retorno.StatusCode = HttpStatusCode.NotFound;
                retorno.Success = false;

                return retorno;
            }
            catch (Exception ex)
            {

                retorno.Errors.Add($"{ex.InnerException}");

                return retorno;
            }
        }

        public RetornoApi<RefreshToken> SalvarRefreshToken(RefreshToken refreshToken)
        {

            RetornoApi<RefreshToken> retorno = new RetornoApi<RefreshToken>() { };

            try
            {
                retorno.Message = "Refresh Token salvo com sucessso!";
                retorno.StatusCode = HttpStatusCode.OK;
                retorno.Success = true;

                _context.RefreshToken.Add(refreshToken);

                var operacao = _context.SaveChanges();

                if (operacao != 1)
                {
                    retorno.Message = "Não foi possivel salvar o refresh token";
                    retorno.StatusCode = HttpStatusCode.InternalServerError;
                    retorno.Success = false;
                    return retorno;
                }


                return retorno;
            }
            catch (Exception ex)
            {

                retorno.Errors.Add($"{ex.InnerException}");

                return retorno;
            }
        }

        public RetornoApi<RefreshToken> AtualizarRefreshToken(RefreshToken refreshToken)
        {

            RetornoApi<RefreshToken> retorno = new RetornoApi<RefreshToken>() { };

            try
            {
                retorno.Message = "Refresh Token salvo com sucessso!";
                retorno.StatusCode = HttpStatusCode.OK;
                retorno.Success = true;

                var refreshTokenAtual = _context.RefreshToken.FirstOrDefault(r => r.Id == refreshToken.Id);


                _context.Entry(refreshTokenAtual).CurrentValues.SetValues(refreshToken);

                var operacao = _context.SaveChanges();

                if (operacao != 1)
                {
                    retorno.Message = "Não foi possivel atualizar o refresh token";
                    retorno.StatusCode = HttpStatusCode.InternalServerError;
                    retorno.Success = false;
                    return retorno;
                }


                return retorno;
            }
            catch (Exception ex)
            {

                retorno.Errors.Add($"{ex.InnerException}");

                return retorno;
            }
        }
    }
}
