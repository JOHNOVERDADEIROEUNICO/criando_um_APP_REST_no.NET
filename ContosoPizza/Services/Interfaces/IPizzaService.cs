using ContosoPizza.DTOs.Pizza;
using ContosoPizza.Models;

namespace ContosoPizza.Services.Interfaces
{
    public interface IPizzaService
    {
        Task<ServiceResponse<List<PizzaResponseDto>>> GetPizza();

        Task<ServiceResponse<List<PizzaResponseDto>>> CreatePizza(PizzaCreateDto dto);

        Task<ServiceResponse<Pizza>> GetPizzaById(int id);

        Task<ServiceResponse<List<Pizza>>> UpdatePizza(Pizza updatePizza);

        Task<ServiceResponse<List<Pizza>>> DeletePizza(int id);
    }
}