using ContosoPizza.Models;
using ContosoPizza.Services.Interfaces;

namespace ContosoPizza.Services.Implementations
{
    public class PizzaService : IPizzaService
    {
        public Task<ServiceResponse<List<Pizza>>> CreatePizza(Pizza newPizza)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Pizza>>> DeletePizza(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Pizza>>> GetPizza()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Pizza>> GetPizzaById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Pizza>>> UpdatePizza(Pizza updatePizza)
        {
            throw new NotImplementedException();
        }
    }
}