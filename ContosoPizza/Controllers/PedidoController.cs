using ContosoPizza.DTOs.Pedido;
using ContosoPizza.Models;
using ContosoPizza.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//No controller ficam todas as requisições http.
namespace ContosoPizza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _PedidoInterface;

        public PedidoController(IPedidoService PedidoInterface)
        {
            _PedidoInterface = PedidoInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<PedidoResponseDto>>>> GetPeiddo()
        {
            return Ok(await _PedidoInterface.GetPedido());
        }

        [HttpPost]
        public async Task<ActionResult<PedidoResponseDto>> CriaPedido(PedidoCreateDto dto)
        {
            var pedido = await _PedidoInterface.CreatePedido(dto);
            return Ok(pedido);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<PedidoResponseDto>>> GetPedidoById(int id)
        {
            var response = await _PedidoInterface.GetPedidoById(id);

            if(!response.Sucesso)
                return NotFound(response.Mensagem);

            return Ok(response);
        }
    }
}