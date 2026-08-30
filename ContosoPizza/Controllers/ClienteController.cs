using ContosoPizza.Models;
using ContosoPizza.Services.Interfaces;
using ContosoPizza.DTOs.Cliente;
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
        public async Task<ActionResult<ServiceResponse<List<ClienteResponseDto>>>> GetClientes()
        {
            return Ok(await _ClienteInterface.GetClientes());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Clientes>>> CreateClientes([FromBody] ClienteCreateDto dto)
        {
            var response = await _ClienteInterface.CreateClientes(dto);

            if(!response.Sucesso)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<ClienteResponseDto>>> UpdateClientes(ClienteUpdateDto dto)
        {
            var response = await _ClienteInterface.UpdateClientes(dto);

            if(!response.Sucesso)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<string>>> DeleteClientes(int id)
        {
            var response = await _ClienteInterface.DeleteClientes(id);

            if(!response.Sucesso)
                return NotFound(response.Mensagem);

            return Ok(response);
        }
    }
}