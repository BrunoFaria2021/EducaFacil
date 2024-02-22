using EducaFacil.Application.DTOs;
using EducaFacil.Application.Interfaces;
using EducaFacil.Application.ViewModel;
using EducaFacil.CrossCutting.Extensions;
using EducaFacil.Domain.Entities;
using EducaFacil.Infrastructure.Data.Interfaces;
using EducaFacil.Infrastructure.Data.Repositpories;
using System.Net;

namespace EducaFacil.Application.Services
{
    public class ResponsavelAppService : IResponsavelAppService
    {
        private readonly IResponsavelRepository _responsavelRepository;
        private readonly IAutenticacaoRepository _autenticacaoRepository;

        public ResponsavelAppService(IResponsavelRepository responsavelRepository, IAutenticacaoRepository autenticacaoRepository)
        {
            _responsavelRepository = responsavelRepository;
            _autenticacaoRepository = autenticacaoRepository;
            _autenticacaoRepository = autenticacaoRepository;
        }

        public Task<RetornoApi<ResponsavelViewModel>> BuscarResponsavelPorId(Guid id, Guid alunoId)
        {
            RetornoApi<ResponsavelViewModel> retorno = new RetornoApi<ResponsavelViewModel>() { };

            var dados =  _responsavelRepository.BuscarResponsavelPorId(id,alunoId);

            if (!dados.Success)
            {
                foreach (var erro in dados.Errors)
                {
                    retorno.Errors.Add(erro);
                }
                retorno.Success = false;
                retorno.Message = dados.Message;
                retorno.StatusCode = dados.StatusCode;
                return Task.FromResult(retorno) ;
            }


            var responsavelViewModel = new ResponsavelViewModel
            {
                Id = dados.Data.Id,
                Nome = dados.Data.Nome,
                Sobrenome = dados.Data.Sobrenome,
                CPF = dados.Data.CPF,
                NumeroContato = dados.Data.NumeroContato,
                WhatsApp = dados.Data.WhatsApp,
                Estado = dados.Data.Estado,
                Endereco = dados.Data.Endereco,
                CodigoPostal = dados.Data.CodigoPostal,
                NumeroEndereco = dados.Data.NumeroEndereco,
                Complemento = dados.Data.Complemento,
                EstadoEndereco = dados.Data.EstadoEndereco,
                Cidade = dados.Data.Cidade,
                Bairro = dados.Data.Bairro,
                Observacao = dados.Data.Observacao,
                DataNascimento = dados.Data.DataNascimento,
                DataAtualizacao = dados.Data.DataAtualizacao,
                DataCriacao = dados.Data.DataCriacao,
                DataVencimento = dados.Data.DataVencimento,
                Alunos = dados.Data.Alunos.Select(aluno =>
                     new AlunoViewModel
                     {
                         Id = aluno.Id,
                         Nome = aluno.Nome,
                         Sobrenome = aluno.Sobrenome,
                         CPF = aluno.CPF,
                         Idade = CalcularIdade(aluno.DataNascimento),
                         Email = aluno.Email,
                         Sexo = aluno.Sexo,
                         Genero = aluno.Genero,
                         Observacao = aluno.Observacao,
                         DataNascimento = aluno.DataNascimento,
                         DataAtualizacao = aluno.DataAtualizacao,
                         DataCriacao = aluno.DataCriacao,
                         ResponsavelId = aluno.ResponsavelId,
                     }).ToList()
            };
            retorno.Message = "Responsável encontrado com sucesso";
            retorno.Data = responsavelViewModel;
            retorno.Success = true;
            retorno.StatusCode = HttpStatusCode.OK;

            return Task.FromResult(retorno);
        }

        public Task<RetornoApi<List<ResponsavelViewModel>>> BuscarTodosOsResponsaveis(Guid alunoId)
        {
            RetornoApi<List<ResponsavelViewModel>> retorno = new RetornoApi<List<ResponsavelViewModel>>();

            var dados = _responsavelRepository.BuscarTodosOsResponsaveis(alunoId);

            if (!dados.Success)
            {
                retorno.Success = false;
                retorno.Message = dados.Message;
                retorno.StatusCode = dados.StatusCode;
                return Task.FromResult(retorno);
            }
            List<ResponsavelViewModel> lista = new List<ResponsavelViewModel>();
            foreach (var responsavelContratante in dados.Data)
            {
                ResponsavelViewModel ResponsavelViewModel = new ResponsavelViewModel()
                {
                    Id = responsavelContratante.Id,
                    Nome = responsavelContratante.Nome,
                    Sobrenome = responsavelContratante.Sobrenome,
                    CPF = responsavelContratante.CPF,
                    NumeroContato = responsavelContratante.NumeroContato,
                    WhatsApp = responsavelContratante.WhatsApp,
                    Estado = responsavelContratante.Estado,
                    Endereco = responsavelContratante.Endereco,
                    CodigoPostal = responsavelContratante.CodigoPostal,
                    NumeroEndereco = responsavelContratante.NumeroEndereco,
                    Complemento = responsavelContratante.Complemento,
                    EstadoEndereco = responsavelContratante.EstadoEndereco,
                    Cidade = responsavelContratante.Cidade,
                    Bairro = responsavelContratante.Bairro,
                    Observacao = responsavelContratante.Observacao,
                    DataNascimento = responsavelContratante.DataNascimento,
                    DataAtualizacao = responsavelContratante.DataAtualizacao,
                    DataCriacao = responsavelContratante.DataCriacao,
                    DataVencimento = responsavelContratante.DataVencimento

                };
                lista.Add(ResponsavelViewModel);
            }

            retorno.Message = "Responsavel encontrados com sucesso";
            retorno.Data = lista;
            retorno.Success = true;
            retorno.StatusCode = HttpStatusCode.OK;

            return Task.FromResult(retorno);
        }
    

        public Task<RetornoApi<ResponsavelViewModel>> CriarResponsavel(ResponsavelContratanteDTO responsavelDTO)
        {
            RetornoApi<ResponsavelViewModel> retorno = new RetornoApi<ResponsavelViewModel>()
            {
                Success = false,
                Message = $"Não foi possível criar o Responsável!",
                StatusCode = HttpStatusCode.BadRequest
            };
            var checarEmail = _autenticacaoRepository.BuscarUsuarioPorEmail(responsavelDTO.Email);

            if (checarEmail.Success)
            {

                retorno.Message = "Este email já esta sendo utilizado";
                retorno.Success = false;
                retorno.StatusCode = HttpStatusCode.BadGateway;

                return Task.FromResult(retorno);
            }
            var senhaSegura = HashSenha.HashSenhaUsuario(responsavelDTO.Senha);

            Responsavel responsavelContratante = new Responsavel()
            {

                Nome = responsavelDTO.Nome,
                Sobrenome = responsavelDTO.Sobrenome,
                CPF = responsavelDTO.CPF,
                NumeroContato = responsavelDTO.NumeroContato,
                WhatsApp = responsavelDTO.WhatsApp,
                Email = responsavelDTO.Email,
                Estado = responsavelDTO.Estado,
                Endereco = responsavelDTO.Endereco,
                CodigoPostal = responsavelDTO.CodigoPostal,
                NumeroEndereco = responsavelDTO.NumeroEndereco,
                Complemento = responsavelDTO.Complemento,
                EstadoEndereco = responsavelDTO.EstadoEndereco,
                Cidade = responsavelDTO.Cidade,
                Bairro = responsavelDTO.Bairro,
                Observacao = responsavelDTO.Observacao,
                Senha = responsavelDTO.Senha,
                DataNascimento = responsavelDTO.DataNascimento,
                DataAtualizacao = DateTime.Now,
                DataCriacao = DateTime.Now


            };

            var resultadoCriacao = _responsavelRepository.CriarResponsavel(responsavelContratante);

            if (!resultadoCriacao.Success)
            {
                foreach (var erro in resultadoCriacao.Errors)
                {
                    retorno.Errors.Add(erro);
                }
                return Task.FromResult(retorno);
            }            

            retorno.Message = "Responsável criado com sucesso";
            retorno.Success = true;
            retorno.StatusCode = HttpStatusCode.OK;

            return Task.FromResult(retorno);
        }
    

        public Task<RetornoApi<ResponsavelViewModel>> DeletarResponsavel(Guid id)
        {
            RetornoApi<ResponsavelViewModel> retorno = new RetornoApi<ResponsavelViewModel>();

            var dados = _responsavelRepository.DeletarResponsavel(id);

            if (!dados.Success)
            {
                retorno.Message = dados.Message;
                retorno.Success = false;
                retorno.StatusCode = dados.StatusCode;
                retorno.Errors.AddRange(dados.Errors);
                return Task.FromResult(retorno);
            }

            retorno.Message = "Responsável deletado com sucesso!";
            retorno.Success = true;
            retorno.StatusCode = HttpStatusCode.OK;

            return Task.FromResult(retorno);
        }

        public  Task<RetornoApi<ResponsavelViewModel>> EditarResponsavel(Guid id, ResponsavelUpdateDTO responsavelDTO)
        {
            RetornoApi<ResponsavelViewModel> retorno = new RetornoApi<ResponsavelViewModel>();

            var checarEmail =  _autenticacaoRepository.BuscarUsuarioPorEmail(responsavelDTO.Email);

            if (checarEmail.Success)
            {
                if (id != checarEmail.Data.Id)
                {
                    retorno.Message = "Este email já está sendo utilizado";
                    retorno.Success = false;
                    retorno.StatusCode = HttpStatusCode.BadGateway;
                    return Task.FromResult(retorno);
                }
            }

            var responsavel = new Responsavel
            {
                Id = id,
                Nome = responsavelDTO.Nome,
                Sobrenome = responsavelDTO.Sobrenome,
                CPF = responsavelDTO.CPF,
                NumeroContato = responsavelDTO.NumeroContato,
                WhatsApp = responsavelDTO.WhatsApp,
                Email = responsavelDTO.Email,
                Estado = responsavelDTO.Estado,
                Endereco = responsavelDTO.Endereco,
                CodigoPostal = responsavelDTO.CodigoPostal,
                NumeroEndereco = responsavelDTO.NumeroEndereco,
                Complemento = responsavelDTO.Complemento,
                EstadoEndereco = responsavelDTO.EstadoEndereco,
                Cidade = responsavelDTO.Cidade,
                Bairro = responsavelDTO.Bairro,
                Observacao = responsavelDTO.Observacao,
                DataNascimento = responsavelDTO.DataNascimento,
                DataAtualizacao = DateTime.Now,
            };

            var resultadoEditar =  _responsavelRepository.EditarResponsavel(id, responsavel);
            return resultadoEditar.Success
                ? Task.FromResult(new RetornoApi<ResponsavelViewModel>
                {
                    Success = true,
                    Message = "Responsável atualizado com sucesso",
                    StatusCode = retorno.StatusCode
                })
                : Task.FromResult(new RetornoApi<ResponsavelViewModel>
                {
                    Success = retorno.Success,
                    Message = retorno.Message,
                    StatusCode = retorno.StatusCode,
                    Errors = retorno.Errors
                });
            
        }

        private int CalcularIdade(DateTime dataNascimento)
        {
            DateTime dataAtual = DateTime.Now;
            int idade = dataAtual.Year - dataNascimento.Year;
            if (dataNascimento.Date > dataAtual.AddYears(-idade)) idade--;
            return idade;
        }
    }
}
