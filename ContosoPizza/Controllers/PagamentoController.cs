using ContosoPizza.DTOs.Pagamento;
using ContosoPizza.Models;
using ContosoPizza.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//No controller ficam todas as requisições http.
namespace ContosoPizza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoService _PagamentoInterface;

        public PagamentoController(IPagamentoService PagamentoInterface)
        {
            _PagamentoInterface = PagamentoInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<PagamentoResponseDto>>>> GetPagamento()
        {
            return Ok(await _PagamentoInterface.GetPagamento());
        }
    }
}