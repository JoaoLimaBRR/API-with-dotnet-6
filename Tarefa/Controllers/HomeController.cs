using Microsoft.AspNetCore.Mvc;

namespace Tarefa.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public string Get()
        {
            return "Hello dotnet 6";
        }
    }
}
