using Microsoft.AspNetCore.Mvc;
using Tarefas.Domain.Entities;
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
        public async Task<ActionResult<IEnumerable<TarefasDomain>>> GetTarefas()
            => Ok(await _tarefaService.GetTarefas());
    }

}
