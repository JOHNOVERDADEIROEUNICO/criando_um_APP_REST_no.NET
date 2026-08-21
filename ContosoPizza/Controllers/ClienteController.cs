using ContosoPizza.Models;
using ContosoPizza.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//No controller ficam todas as requisições http.
namespace ContosoPizza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _ClienteInterface;

        public ClienteController(IClienteService ClienteInterface)
        {
            _ClienteInterface = ClienteInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<Clientes>>> GetClientes()
        {
            return Ok(await _ClienteInterface.GetClientes());
        }
    }
}