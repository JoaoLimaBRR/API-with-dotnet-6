using Microsoft.AspNetCore.Mvc;
using Tarefa.Data;
using Tarefa.Model;

namespace Tarefa.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Buscar([FromServices] AppDbContext context)
            => Ok(context.Tarefas.ToList());

        [HttpGet("/{id:int}")]
        public IActionResult BuscarPorId([FromServices] AppDbContext context, [FromRoute] int id)
        {
            var tarefas = context.Tarefas.FirstOrDefault(x => x.Id == id);
            if (tarefas == null)
                return NotFound();

            return Ok(tarefas);
        }

        [HttpPost("/CriarTarefa")]
        public IActionResult Criar([FromServices] AppDbContext context, [FromBody] TarefaModel tarefa)
        {
            context.Tarefas.Add(tarefa);
            context.SaveChanges();

            return Created($"/{tarefa.Id}", tarefa);
        }

        [HttpPut("/AtualizarTarefa")]
        public IActionResult Atualizar([FromServices] AppDbContext context, [FromBody] TarefaModel tarefa)
        {
            var model = context.Tarefas.FirstOrDefault(x => x.Id == tarefa.Id);
            if (model == null)
                return NotFound();

            model.Titulo = tarefa.Titulo;
            model.Finalizada = tarefa.Finalizada;

            context.Tarefas.Update(model);
            context.SaveChanges();

            return Ok(model);
        }

        [HttpDelete("/DeletarTarefa/{id:int}")]
        public IActionResult Detelar([FromServices] AppDbContext context, [FromRoute] int id)
        {
            var model = context.Tarefas.FirstOrDefault(x => x.Id == id);
            if (model == null)
                return NotFound();

            context.Tarefas.Remove(model);
            context.SaveChanges();

            return Ok(model);
        }
    }
}
