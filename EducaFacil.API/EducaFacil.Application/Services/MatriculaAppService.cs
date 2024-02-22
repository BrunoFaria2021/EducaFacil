using EducaFacil.Application.DTOs;
using EducaFacil.Application.Interfaces;
using EducaFacil.Application.ViewModel;
using EducaFacil.CrossCutting.Extensions;
using EducaFacil.Domain.Entities;
using EducaFacil.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EducaFacil.Application.Services
{
    public class MatriculaAppService : IMatriculaAppService
    {
        private readonly ApplicationDbContext _context;

        public MatriculaAppService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<RetornoApi<MatriculaViewModel>> CancelarMatricula(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<RetornoApi<MatriculaViewModel>> MatricularAluno(MatriculaDTO matriculaDTO)
        {
            RetornoApi<MatriculaViewModel> retorno = new RetornoApi<MatriculaViewModel>()
            {
                Success = false,
                Message = $"Não foi possível matricular o aluno!",
                StatusCode = HttpStatusCode.BadRequest
            };

            
            if (matriculaDTO.AlunoId == Guid.Empty || matriculaDTO.SerieId == Guid.Empty || matriculaDTO.ResponsavelId == Guid.Empty)
            {
                retorno.Message = "Dados de entrada inválidos";
                retorno.StatusCode = HttpStatusCode.BadRequest;
                return retorno;
            }

            // Verificação da existência do aluno, série e responsável
            var aluno = await _context.Alunos.FindAsync(matriculaDTO.AlunoId);
            var serie = await _context.Series.FindAsync(matriculaDTO.SerieId);
            var responsavel = await _context.Responsaveis.FindAsync(matriculaDTO.ResponsavelId);

            if (aluno == null || serie == null || responsavel == null)
            {
                retorno.Message = "Aluno, série ou responsável não encontrados";
                retorno.StatusCode = HttpStatusCode.NotFound;
                return retorno;
            }

            // Criação da matrícula
            var novaMatricula = new Matricula
            {
                AlunoId = matriculaDTO.AlunoId,
                SerieId = matriculaDTO.SerieId,
                ResponsavelId = matriculaDTO.ResponsavelId,
                DataMatricula = DateTime.Now
            };

            // Adicionar a nova matrícula ao contexto do banco de dados
            _context.Matriculas.Add(novaMatricula);

            // Salvar as alterações no banco de dados
            var resultado = await _context.SaveChangesAsync();

            if (resultado > 0)
            {
                // Atualizar o aluno com a nova matrícula
                //aluno.MatriculaId = novaMatricula.Id;
                _context.Alunos.Update(aluno);
                await _context.SaveChangesAsync();

                // Mapear a matrícula do domínio para a ViewModel
                var matriculaViewModel = new MatriculaViewModel
                {
                    Id = novaMatricula.Id,
                    AlunoId = novaMatricula.AlunoId,
                    SerieId = novaMatricula.SerieId,
                    ResponsavelId = novaMatricula.ResponsavelId,
                    DataMatricula = novaMatricula.DataMatricula
                };

                retorno.Success = true;
                retorno.Data = matriculaViewModel;
                retorno.Message = "Aluno matriculado com sucesso";
                retorno.StatusCode = HttpStatusCode.OK;
                return retorno;
            }
            else
            {
                retorno.Message = "Não foi possível matricular o aluno";
                retorno.StatusCode = HttpStatusCode.InternalServerError;
                return retorno;
            }
        }

        public Task<RetornoApi<MatriculaViewModel>> ObterMatriculaPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

