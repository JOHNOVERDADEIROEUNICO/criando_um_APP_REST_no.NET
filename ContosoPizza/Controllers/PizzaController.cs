using ContosoPizza.Models;
using ContosoPizza.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//No controller ficam todas as requisições http.
namespace ContosoPizza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _PizzaInterface;

        public PizzaController(IPizzaService PizzaInterface)
        {
            _PizzaInterface = PizzaInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<Pizza>>> GetPizza()
        {
            return Ok(await _PizzaInterface.GetPizza());
        }
    }
}