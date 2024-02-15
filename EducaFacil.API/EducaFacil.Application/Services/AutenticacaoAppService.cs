using EducaFacil.Application.Interfaces;
using EducaFacil.Application.ViewModel;
using EducaFacil.Infrastructure.Data.Interfaces;
using GestaoDiet.Application.DTOs;
using GestaoDiet.CrossCutting.Extensions;
using GestaoDiet.Domain.Entities;
using GestaoDiet.Infra.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDiet.Application.Services
{
    public class AutenticacaoAppService: IAutenticacaoAppService
    {
        private readonly IAutenticacaoRepository _autenticacaoRepository;
        private readonly IConfiguration _configuration;
        public AutenticacaoAppService(IAutenticacaoRepository autenticacaoRepository, IConfiguration configuration)
        {
            _autenticacaoRepository = autenticacaoRepository;
            _configuration = configuration;
        }

        public async Task<RetornoApi<AutenticacaoViewModel>> Login(LoginDTO loginDTO)
        {
            var consulta = _autenticacaoRepository.BuscarUsuarioPorEmail(loginDTO.Login);

            if (!consulta.Success)
            {
                return new RetornoApi<AutenticacaoViewModel>
                {
                    Success = false,
                    Message = "Login e/ou Senha inválido",
                    StatusCode = System.Net.HttpStatusCode.Unauthorized
                };
            }

            var senhaHash = (string)consulta.Data.Senha;
            bool verificacao = HashSenha.VerificarSenha(loginDTO.Senha, senhaHash);

            if (verificacao)
            {
                var tokenERefreshToken = await AgruparTokenERefreshToken(consulta.Data.Id);

                if (tokenERefreshToken != null)
                {
                    return new RetornoApi<AutenticacaoViewModel>
                    {
                        Data = tokenERefreshToken,
                        Success = true,
                        Message = "Autenticação realizada com sucesso!",
                        StatusCode = System.Net.HttpStatusCode.OK,
                    };
                }
                else
                {
                    return new RetornoApi<AutenticacaoViewModel>
                    {
                        Success = false,
                        Message = "Houve um erro ao formar o token!",
                        StatusCode = System.Net.HttpStatusCode.InternalServerError
                    };
                }
            }
            else
            {
                return new RetornoApi<AutenticacaoViewModel>
                {
                    Success = false,
                    Message = "Login e/ou Senha inválido",
                    StatusCode = System.Net.HttpStatusCode.Unauthorized
                };
            }
        }
        public  RetornoApi<TokenAcesso> RefreshToken(string refreshToken) 
        {

            TokenAcesso tokenAcesso = new TokenAcesso();

            var chave = _configuration.GetSection("AutenticacaoApi")["Secret"];

            var valido = ValidarToken(refreshToken);

            if (!valido) {

               return new RetornoApi<TokenAcesso>
                {
                    Success = false,
                    Message = "Refresh token inválido!",
                    StatusCode = System.Net.HttpStatusCode.Unauthorized,
                };

            }

            var usuarioId = ObterUsuarioIdNoToken(refreshToken);

            if (usuarioId != null && chave != null) {

               var dadosToken = GerarToken((Guid)usuarioId, chave);

                tokenAcesso.ExpiracaoToken = dadosToken.Item2;
                tokenAcesso.Token = dadosToken.Item1;

              return  new RetornoApi<TokenAcesso>
                {
                    Data = tokenAcesso,
                    Success = true,
                    Message = "Token criado com sucesso!",
                    StatusCode = System.Net.HttpStatusCode.OK,
                };
            }

            return new RetornoApi<TokenAcesso>
            {
                Success = false,
                Message = "Usuario não encontrado ou chave não encontrada!",
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
            };

        }
        private async Task<AutenticacaoViewModel?> AgruparTokenERefreshToken(Guid usuarioId)
        {

            // token
            var chave = _configuration.GetSection("AutenticacaoApi")["Secret"];

            if (chave != null)
            {
                var dadosToken = GerarToken(usuarioId, chave);
                var Expiracao = dadosToken.Item2;
                var escrevendoToken = dadosToken.Item1;

                // refresh token

                var refreshTokenExistente = _autenticacaoRepository.BuscarRefreshToken(usuarioId);

                Tuple<string, DateTime> novoRefreshToken = new Tuple<string, DateTime>(null, DateTime.Now);
                string stringRefreshToken = "";
                DateTime dataExpiracaoRefreshToken = new DateTime();


                if (!refreshTokenExistente.Success)
                {

                    novoRefreshToken = GerarRefreshToken(usuarioId);

                    stringRefreshToken = novoRefreshToken.Item1;

                    dataExpiracaoRefreshToken = novoRefreshToken.Item2;

                    RefreshToken refreshToken = new RefreshToken
                    {
                        UsuarioId = usuarioId,
                        ExpiraEm = novoRefreshToken.Item2,
                        DataUltimoUso = DateTime.Now,
                        Refresh_Token = novoRefreshToken.Item1
                    };


                    var salvarRefresh = _autenticacaoRepository.SalvarRefreshToken(refreshToken);

                    if (!salvarRefresh.Success)
                    {

                        return null;

                    }

                    return new AutenticacaoViewModel()
                    {
                        TokenAcesso = new TokenAcesso()
                        {
                            ExpiracaoToken = Expiracao,
                            Token = escrevendoToken
                        },
                        RefreshTokenAcesso = new RefreshTokenAcesso()
                        {
                            ExpiracaoRefreshToken = dataExpiracaoRefreshToken,
                            RefreshToken = stringRefreshToken
                        }
                    };



                }


                novoRefreshToken = GerarRefreshToken(usuarioId);

                refreshTokenExistente.Data.ExpiraEm = novoRefreshToken.Item2;

                refreshTokenExistente.Data.Refresh_Token = novoRefreshToken.Item1;

                refreshTokenExistente.Data.DataUltimoUso = DateTime.Now;

                _autenticacaoRepository.AtualizarRefreshToken(refreshTokenExistente.Data);

                stringRefreshToken = novoRefreshToken.Item1;

                dataExpiracaoRefreshToken = novoRefreshToken.Item2;



                return new AutenticacaoViewModel()
                {
                    TokenAcesso = new TokenAcesso()
                    {
                        ExpiracaoToken = Expiracao,
                        Token = escrevendoToken
                    },
                    RefreshTokenAcesso = new RefreshTokenAcesso()
                    {
                        ExpiracaoRefreshToken = dataExpiracaoRefreshToken,
                        RefreshToken = stringRefreshToken
                    }
                };
            }   

            return null;

        }
        private Tuple<string, DateTime> GerarToken(Guid usuarioId, string chave) {

            byte[] codigo;

            codigo = Encoding.ASCII.GetBytes(chave);

            // Obtendo a data e hora atual
            var agora = DateTime.UtcNow;

            // Adicionando exatamente 1 dia usando TimeSpan
            var expiracao = agora + TimeSpan.FromDays(1);

            var configuracaoToken = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(new Claim[] { new Claim("Id", usuarioId.ToString()) }),
                Expires = expiracao,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(codigo), SecurityAlgorithms.HmacSha256Signature)
            };

            var manipulandoToken = new JwtSecurityTokenHandler();
            var criandoToken = manipulandoToken.CreateToken(configuracaoToken);
            var escrevendoToken = manipulandoToken.WriteToken(criandoToken);

            return Tuple.Create(escrevendoToken, expiracao);
        }
        private Tuple<string, DateTime> GerarRefreshToken(Guid UsuarioId)
        {

            var chave = _configuration.GetSection("AutenticacaoApi")["RefreshSecret"];

            byte[] codigo;

            if (chave != null)
            {

                codigo = Encoding.ASCII.GetBytes(chave);

                // Obtendo a data e hora atual
                var agora = DateTime.UtcNow;

                // Adicionando exatamente 1 dia usando TimeSpan
                var expiracao = agora + TimeSpan.FromDays(4);

                var configuracaoRefreshToken = new SecurityTokenDescriptor
                {

                    Subject = new ClaimsIdentity(new Claim[] { new Claim("Id", UsuarioId.ToString()) }),
                    Expires = expiracao,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(codigo), SecurityAlgorithms.HmacSha256Signature)
                };

                var manipulandoToken = new JwtSecurityTokenHandler();
                var criandoToken = manipulandoToken.CreateToken(configuracaoRefreshToken);
                var refreshToken = manipulandoToken.WriteToken(criandoToken);

                return Tuple.Create(refreshToken, expiracao);
            }

            return null;
        }
        private  bool ValidarToken(string token)
        {

            var chaveDeAcesso = _configuration.GetSection("AutenticacaoApi")["RefreshSecret"];

            var chaveBytes = Encoding.ASCII.GetBytes(chaveDeAcesso);

            var tokenHandler = new JwtSecurityTokenHandler();


            var parametros = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(chaveBytes),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true, // Verificar tempo de expiração
                ClockSkew = TimeSpan.Zero // Sem tolerância para a diferença de tempo
            };

            try
            {
                var principal = tokenHandler.ValidateToken(token, parametros, out _);
                return true; // Token é válido
            }
            catch (Exception)
            {
                return false; // Token inválido
            }
        }
        private Guid? ObterUsuarioIdNoToken(string token) {

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            if (jwtToken != null)
            {
                var idClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "Id");

                if (idClaim != null)
                {
                    if (Guid.TryParse(idClaim.Value, out Guid idGuid))
                    {
                        return idGuid;
                    }
                    return null;
                }
            }
            return null;

        }
    
    }
}
