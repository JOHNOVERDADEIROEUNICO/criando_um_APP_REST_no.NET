using ContosoPizza.DTOs.ItemPedido;
using ContosoPizza.Models;
using ContosoPizza.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//No controller ficam todas as requisições http.
namespace ContosoPizza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPedidoController : ControllerBase
    {
        private readonly IItemPedidoService _ItemPedidoInterface;

        public ItemPedidoController(IItemPedidoService ItemInterface)
        {
            _ItemPedidoInterface = ItemInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ItemPedidoResponseDto>>>> GetItemPedido()
        {
            return Ok(await _ItemPedidoInterface.GetItemPedido());
        }
    }
}