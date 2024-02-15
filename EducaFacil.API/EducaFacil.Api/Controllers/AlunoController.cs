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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AlunoDTO alunoDTO)
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] AlunoUpdateDTO alunoDTO)
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
