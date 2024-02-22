using EducaFacil.Application.DTOs;
using EducaFacil.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EducaFacil.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaAppService _matriculaAppService;

        public MatriculaController(IMatriculaAppService matriculaAppService)
        {
            _matriculaAppService = matriculaAppService;
        }

        [HttpPost("Matricular")]
        public async Task<IActionResult> MatricularAluno([FromBody] MatriculaDTO matriculaDTO)
        {
            var resultado = await _matriculaAppService.MatricularAluno(matriculaDTO);

            if (!resultado.Success)
            {
                if (resultado.StatusCode == HttpStatusCode.NotFound)
                    return NotFound(resultado);

                if (resultado.StatusCode == HttpStatusCode.BadRequest)
                    return BadRequest(resultado);

                if (resultado.StatusCode == HttpStatusCode.InternalServerError)
                    return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("ObterPorId/{id}")]
        public async Task<IActionResult> ObterMatriculaPorId(Guid id)
        {
            var resultado = await _matriculaAppService.ObterMatriculaPorId(id);

            if (!resultado.Success)
            {
                if (resultado.StatusCode == HttpStatusCode.NotFound)
                    return NotFound(resultado);

                if (resultado.StatusCode == HttpStatusCode.BadRequest)
                    return BadRequest(resultado);

                if (resultado.StatusCode == HttpStatusCode.InternalServerError)
                    return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }

        [HttpDelete("Cancelar/{id}")]
        public async Task<IActionResult> CancelarMatricula(Guid id)
        {
            var resultado = await _matriculaAppService.CancelarMatricula(id);

            if (!resultado.Success)
            {
                if (resultado.StatusCode == HttpStatusCode.NotFound)
                    return NotFound(resultado);

                if (resultado.StatusCode == HttpStatusCode.BadRequest)
                    return BadRequest(resultado);

                if (resultado.StatusCode == HttpStatusCode.InternalServerError)
                    return StatusCode(500, resultado);
            }

            return Ok(resultado);
        }
    }
}
