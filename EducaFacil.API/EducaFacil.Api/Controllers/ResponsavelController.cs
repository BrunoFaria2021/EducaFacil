using EducaFacil.Application.DTOs;
using EducaFacil.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EducaFacil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsavelController : ControllerBase
    {
        private readonly IResponsavelAppService _responsavelAppService;

        public ResponsavelController(IResponsavelAppService responsavelAppService)
        {
            _responsavelAppService = responsavelAppService;
        }

        [HttpGet("BuscarPorId/{id}")]
        public async Task<IActionResult> BuscarResponsavelPorId(Guid id, Guid alunoId)
        {
            try
            {
                var resultado = await _responsavelAppService.BuscarResponsavelPorId(id, alunoId);

                if (!resultado.Success)
                {
                    if (resultado.StatusCode == HttpStatusCode.NotFound)
                        return NotFound(resultado);

                    if (resultado.StatusCode == HttpStatusCode.BadRequest)
                        return BadRequest(resultado);

                    if (resultado.StatusCode == HttpStatusCode.InternalServerError)
                        BadRequest(resultado);
                }

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("BuscarTodos/{id}")]
        public async Task<IActionResult> BuscarTodosOsResponsaveis(Guid id)
        {
            var resultado = await _responsavelAppService.BuscarTodosOsResponsaveis(id);

            if (!resultado.Success)
            {
                if (resultado.StatusCode == HttpStatusCode.NotFound)
                    return NotFound(resultado);

                if (resultado.StatusCode == HttpStatusCode.BadRequest)
                    return BadRequest(resultado);

                if (resultado.StatusCode == HttpStatusCode.InternalServerError)
                    BadRequest(resultado);
            }

            return Ok(resultado);
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> CriarResponsavel([FromBody] ResponsavelContratanteDTO responsavelDTO)
        {
            try
            {
                var resultado = await _responsavelAppService.CriarResponsavel(responsavelDTO);

                if (!resultado.Success)
                {
                    if (resultado.StatusCode == HttpStatusCode.NotFound)
                        return NotFound(resultado);

                    if (resultado.StatusCode == HttpStatusCode.BadRequest)
                        return BadRequest(resultado);

                    if (resultado.StatusCode == HttpStatusCode.InternalServerError)
                        BadRequest(resultado);
                }

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("Deletar/{id}")]
        public async Task<IActionResult> DeletarResponsavel(Guid id)
        {
            try
            {
                var resultado = await _responsavelAppService.DeletarResponsavel(id);

                if (!resultado.Success)
                {
                    if (resultado.StatusCode == HttpStatusCode.NotFound)
                        return NotFound(resultado);

                    if (resultado.StatusCode == HttpStatusCode.BadRequest)
                        return BadRequest(resultado);

                    if (resultado.StatusCode == HttpStatusCode.InternalServerError)
                        BadRequest(resultado);
                }

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut("Editar/{id}")]
        public async Task<IActionResult> EditarResponsavel(Guid id, [FromBody] ResponsavelUpdateDTO responsavelDTO)
        {
            try
            {
                var resultado = await _responsavelAppService.EditarResponsavel(id, responsavelDTO);

                if (!resultado.Success)
                {
                    if (resultado.StatusCode == HttpStatusCode.NotFound)
                        return NotFound(resultado);

                    if (resultado.StatusCode == HttpStatusCode.BadRequest)
                        return BadRequest(resultado);

                    if (resultado.StatusCode == HttpStatusCode.InternalServerError)
                        BadRequest(resultado);
                }

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
