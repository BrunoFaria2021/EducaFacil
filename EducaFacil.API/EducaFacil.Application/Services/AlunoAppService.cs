using EducaFacil.Application.DTOs;
using EducaFacil.Application.Interfaces;
using EducaFacil.Application.ViewModel;
using EducaFacil.CrossCutting.Extensions;
using EducaFacil.Domain.Entities;
using EducaFacil.Infrastructure.Data.Interfaces;
using System.Net;

namespace EducaFacil.Application.Services
{
    public class AlunoAppService : IAlunoAppService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IResponsavelRepository _responsavelRepository;
        private readonly IAutenticacaoRepository _autenticacaoRepository;

        public AlunoAppService(IAlunoRepository alunoRepository, IResponsavelRepository responsavelRepository, IAutenticacaoRepository autenticacaoRepository)
        {
            _alunoRepository = alunoRepository;
            _responsavelRepository = responsavelRepository;
            _autenticacaoRepository = autenticacaoRepository;
        }

        public async Task<RetornoApi<AlunoViewModel>> BuscarAlunoId(Guid id)
        {
            RetornoApi<AlunoViewModel> retorno = new RetornoApi<AlunoViewModel>() { };

            var dados = _alunoRepository.BuscarAlunoId(id);

            if (!dados.Success)
            {
                foreach (var erro in dados.Errors)
                {
                    retorno.Errors.Add(erro);
                }
                retorno.Success = false;
                retorno.Message = dados.Message;
                retorno.StatusCode = dados.StatusCode;
                return retorno;
            }

            AlunoViewModel alunoViewModel = new AlunoViewModel()
            {
                Id = id,
                Nome = dados.Data.Nome,
                Sobrenome = dados.Data.Sobrenome,
                CPF = dados.Data.CPF,
                Idade = CalcularIdade(dados.Data.DataNascimento),
                Email = dados.Data.Email,
                Sexo = dados.Data.Sexo,
                Genero = dados.Data.Genero,
                Observacao = dados.Data.Observacao,
                DataNascimento = dados.Data.DataNascimento,
                DataAtualizacao = dados.Data.DataAtualizacao,
                DataCriacao = dados.Data.DataCriacao,
                ResponsavelId = dados.Data.ResponsavelId,


            };
            retorno.Message = "Aluno Encontrado com Sucesso";
            retorno.Data = alunoViewModel;
            retorno.Success = true;
            retorno.StatusCode = HttpStatusCode.OK;
            return retorno;
        }
        public async Task<RetornoApi<List<AlunoViewModel>>> BuscarTodosOsAlunos(Guid responsavelId)
        {
            RetornoApi<List<AlunoViewModel>> retorno = new RetornoApi<List<AlunoViewModel>>();

            var dados =  _alunoRepository.BuscarTodosOsAlunos(responsavelId);

            if (!dados.Success)
            {
                retorno.Success = false;
                retorno.Message = dados.Message;
                retorno.StatusCode = dados.StatusCode;
                return retorno;
            }

            List<AlunoViewModel> listaAlunosViewModel = new List<AlunoViewModel>();

            foreach (var aluno in dados.Data)
            {
                AlunoViewModel alunoViewModel = new AlunoViewModel()
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
                   

                };

                listaAlunosViewModel.Add(alunoViewModel);
            }

            retorno.Message = "Alunos Encontrados com Sucesso";
            retorno.Data = listaAlunosViewModel;
            retorno.Success = true;
            retorno.StatusCode = HttpStatusCode.OK;

            return retorno;
        }
        public Task<RetornoApi<AlunoViewModel>> CriarAluno(AlunoDTO alunoDTO)
        {
            RetornoApi<AlunoViewModel> retorno = new RetornoApi<AlunoViewModel>()
            {
                Success = false,
                Message = $"Não foi possivel criar o Aluno!",
                StatusCode = HttpStatusCode.BadRequest
            };
            var checarEmail = _autenticacaoRepository.BuscarUsuarioPorEmail(alunoDTO.Email);

            if (checarEmail.Success)
            {

                retorno.Message = "Este email já esta sendo utilizado";
                retorno.Success = false;
                retorno.StatusCode = HttpStatusCode.BadGateway;

                return Task.FromResult(retorno);
            }

            var senhaSegura = HashSenha.HashSenhaUsuario(alunoDTO.Senha);

            Aluno aluno = new Aluno()
            {
                Nome = alunoDTO.Nome,
                Sobrenome = alunoDTO.Sobrenome,
                CPF = alunoDTO.CPF,
                Senha = senhaSegura,
                Email = alunoDTO.Email,
                Sexo = alunoDTO.Sexo,
                Genero = alunoDTO.Genero,
                Observacao = alunoDTO.Observacao,
                DataNascimento = alunoDTO.DataNascimento,
                DataAtualizacao = alunoDTO.DataAtualizacao,
                DataCriacao = alunoDTO.DataCriacao,
                ResponsavelId = alunoDTO.ResponsavelId
            };
            var dados = _alunoRepository.CriarAluno(aluno);

            if (!dados.Success)
            {
                foreach (var erro in dados.Errors)
                {

                    retorno.Errors.Add(erro);

                }
                return Task.FromResult(retorno);
            }

            retorno.Message = "Aluno criado com Sucesso";
            retorno.Success = true;
            retorno.StatusCode = HttpStatusCode.OK;

            return Task.FromResult(retorno);
        }

        public Task<RetornoApi<AlunoViewModel>> DeletarAluno(Guid id)
        {
            RetornoApi<AlunoViewModel> retorno = new RetornoApi<AlunoViewModel>();

            var dados = _alunoRepository.DeletarAluno(id);

            if (!dados.Success)
            {
                retorno.Message = dados.Message;
                retorno.Success = false;
                retorno.StatusCode = dados.StatusCode;
                retorno.Errors.AddRange(dados.Errors);
                return Task.FromResult(retorno);
            }

            retorno.Message = "Aluno deletado com sucesso!";
            retorno.Success = true;
            retorno.StatusCode = HttpStatusCode.OK;

            return Task.FromResult(retorno);
        }

        public Task<RetornoApi<AlunoViewModel>> EditarAluno(Guid id, AlunoUpdateDTO alunoDTO)
        {
            throw new NotImplementedException();
        }

        // Método para calcular a idade com base na data de nascimento
        private int CalcularIdade(DateTime dataNascimento)
        {
            DateTime dataAtual = DateTime.Now;
            int idade = dataAtual.Year - dataNascimento.Year;
            if (dataNascimento.Date > dataAtual.AddYears(-idade)) idade--;
            return idade;
        }

    }
}
