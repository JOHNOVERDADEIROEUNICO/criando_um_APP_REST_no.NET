using ContosoPizza.DataContext;
using ContosoPizza.Models;
using ContosoPizza.Services.Interfaces;

namespace ContosoPizza.Services.Implementations
{
    public class PizzaService : IPizzaService
    {
        private readonly ApplicationDbContext _context;

        public PizzaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<ServiceResponse<List<Pizza>>> CreatePizza(Pizza newPizza)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Pizza>>> DeletePizza(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<Pizza>>> GetPizza()
        {
            ServiceResponse<List<Pizza>> serviceResponse = new ServiceResponse<List<Pizza>>();

            try
            {
                serviceResponse.Dados = _context.Pizza.ToList();
                if(serviceResponse.Dados.Count == 0)
                    serviceResponse.Mensagem = "Nenhum Dado Registrado.";
            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
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