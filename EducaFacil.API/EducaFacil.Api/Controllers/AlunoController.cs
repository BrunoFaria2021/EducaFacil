using EducaFacil.Application.DTOs;
using EducaFacil.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EducaFacil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoAppService _alunoAppService;

        public AlunoController(IAlunoAppService alunoAppService)
        {
            _alunoAppService = alunoAppService;
        }

        [HttpGet("BuscarAlunoId")]
        public async Task<IActionResult> BuscarAlunoId(Guid id)
        {
            var resultado = await _alunoAppService.BuscarAlunoId(id);

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
        [HttpGet("{responsavelId}")]
        public async Task<IActionResult> BuscarTodosOsAlunos(Guid responsavelId)
        {
            var resultado = await _alunoAppService.BuscarTodosOsAlunos(responsavelId);

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

        [HttpPost("CriarAluno")]
        public async Task<IActionResult> CriarAluno([FromBody] AlunoDTO alunoDTO)
        {
            var resultado = await _alunoAppService.CriarAluno(alunoDTO);

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

        [HttpDelete("{id}DeletarAluno")]
        public async Task<IActionResult> DeletarAluno(Guid id)
        {
            var resultado = await _alunoAppService.DeletarAluno(id);

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

        [HttpPut("{id}EditarAluno")]
        public async Task<IActionResult> EditarAluno(Guid id, [FromBody] AlunoUpdateDTO alunoDTO)
        {
            var resultado = await _alunoAppService.EditarAluno(id, alunoDTO);

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
    }
}
