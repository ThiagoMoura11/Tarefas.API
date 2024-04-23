using Microsoft.AspNetCore.Mvc;
using Tarefas.Domain.Entities;
using Tarefas.Domain.ViewModels;
using Tarefas.Service;
using Tarefas.Service.Interface;

namespace Tarefas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;

        public TarefasController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpGet("BuscarTarefas")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<TarefasDomain>>> GetTarefas()
        {
            var tarefas = await _tarefaService.GetTarefas();
            return tarefas != null ? Ok(tarefas) : NotFound();
        }

        [HttpPost("AdicionarTarefas")]
        [ProducesResponseType(201)] 
        [ProducesResponseType(400)] 
        public ActionResult<TarefasViewModel> AddTarefa([FromBody] TarefasViewModel tarefas)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(new ValidationProblemDetails(ModelState)
                {
                    Detail = "Os parametros fornecidos são invalidos"
                });
            }
            return Created("", _tarefaService.AddTarefa(tarefas));
        }

        [HttpPut("AtualizarTarefas")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<TarefasDomain> UpdateTarefas([FromRoute] Guid id, [FromBody] TarefasDomain tarefas)
        {
            try
            {
                var resposta = _tarefaService.UpdateTarefa(id, tarefas);
                if (resposta == null)
                {
                    return NotFound("Tarefa não encontrada.");
                }
                return Ok(resposta);
            }
            catch
            {
                return BadRequest("Erro ao atualizar a tarefa.");
            }
        }

        [HttpDelete("DeletarTarefas/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<bool> DeleteTarefa(Guid id)
        {
            try
            {
                var resultado = _tarefaService.DeleteTarefa(id);
                if (resultado == null)
                {
                    return NotFound("Tarefa não encontrada.");
                }
                return Ok(resultado);
            }
            catch
            {
                return StatusCode(500, "Erro interno do servidor.");
            }
        }
    }   

}
