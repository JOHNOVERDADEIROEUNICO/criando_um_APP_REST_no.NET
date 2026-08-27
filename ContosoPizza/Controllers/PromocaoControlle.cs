using ContosoPizza.DTOs.Promocao;
using ContosoPizza.Models;
using ContosoPizza.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//No controller ficam todas as requisições http.
namespace ContosoPizza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocaoController : ControllerBase
    {
        private readonly IPromocaoService _PromocaoInterface;

        public PromocaoController(IPromocaoService PromocaoInterface)
        {
            _PromocaoInterface = PromocaoInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Promocao>>>> GetPromocao()
        {
            return Ok(await _PromocaoInterface.GetPromocao());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<PromocaoResponseDto>>> CreatePromocao(PromocaoCreateDto dto)
        {
            return Ok(await _PromocaoInterface.CreatePromocao(dto));
        }
    }
}