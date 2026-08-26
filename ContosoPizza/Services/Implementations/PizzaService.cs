using ContosoPizza.DataContext;
using ContosoPizza.DTOs.Pizza;
using ContosoPizza.Models;
using ContosoPizza.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services.Implementations
{
    public class PizzaService : IPizzaService
    {
        private readonly ApplicationDbContext _context;

        public PizzaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<PizzaResponseDto>>> CreatePizza(PizzaCreateDto dto)
        {
            ServiceResponse<List<PizzaResponseDto>> serviceResponse = new ServiceResponse<List<PizzaResponseDto>>();

            try
            {
                if(dto.Preco <= 0)
                    throw new Exception("Valor de preço inválido");
                
                var pizza = new Pizza
                {
                    Nome = dto.Nome,
                    Preco = dto.Preco
                };

                _context.Pizza.Add(pizza);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = await _context.Pizza.Select(i => new PizzaResponseDto
                {
                    Id = i.Id,
                    Nome = i.Nome,
                    Preco = i.Preco
                    
                }).ToListAsync();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;

            }

            return serviceResponse;
        }

        public Task<ServiceResponse<List<Pizza>>> DeletePizza(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<PizzaResponseDto>>> GetPizza()
        {
            ServiceResponse<List<PizzaResponseDto>> serviceResponse = new ServiceResponse<List<PizzaResponseDto>>();

            try
            {
                var pizza = await _context.Pizza.ToListAsync();

                var pizzaDto = pizza.Select(p => new PizzaResponseDto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Preco = p.Preco

                }).ToList();

                serviceResponse.Dados = pizzaDto;
                
                if(pizzaDto.Count == 0)
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