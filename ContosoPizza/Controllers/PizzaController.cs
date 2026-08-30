using ContosoPizza.DTOs.Pizza;
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
        public async Task<ActionResult<ServiceResponse<List<PizzaResponseDto>>>> GetPizza()
        {
            return Ok(await _PizzaInterface.GetPizza());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<PizzaResponseDto>>> CreatePizza(PizzaCreateDto dto)
        {
            return Ok(await _PizzaInterface.CreatePizza(dto));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<PizzaResponseDto>>> UpdatePizza(PizzaUpdateDto dto)
        {
            var response = await _PizzaInterface.UpdatePizza(dto);

            if(!response.Sucesso)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<string>>> DeletePizza(int id)
        {
            var response = await _PizzaInterface.DeletePizza(id);

            if(!response.Sucesso)
                return NotFound(response.Mensagem);

            return Ok(response);
        }
    }
}