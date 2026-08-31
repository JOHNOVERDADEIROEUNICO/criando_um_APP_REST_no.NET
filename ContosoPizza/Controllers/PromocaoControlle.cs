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

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<PromocaoResponseDto>>> UpdatePromocao(PromocaoUpdateDto dto)
        {
            var response = await _PromocaoInterface.UpdatePromocao(dto);

            if(!response.Sucesso)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<string>>> DeletePromocao(int id)
        {
            var response = await _PromocaoInterface.DeletePromocao(id);

            if(!response.Sucesso)
                return NotFound(response.Mensagem);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<PromocaoResponseDto>>> GetPromocaoById(int id)
        {
            var response = await _PromocaoInterface.GetPromocaoById(id);

            if(!response.Sucesso)
                return NotFound(response.Mensagem);

            return Ok(response);
        }
    }
}