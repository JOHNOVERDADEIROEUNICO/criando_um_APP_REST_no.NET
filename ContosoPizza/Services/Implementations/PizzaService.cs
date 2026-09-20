using ContosoPizza.DataContext;
using ContosoPizza.DTOs.Pizza;
using ContosoPizza.Models;
using ContosoPizza.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

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

        public async Task<ServiceResponse<string>> DeletePizza(int id)
        {
            ServiceResponse<string> serviceResponse = new();

            try
            {
                var pizza = await _context.Pizza
                    .FirstOrDefaultAsync(p => p.Id == id)
                    ?? throw new Exception("Nenhuma pizza encontrada");

                var itensPedidos = await _context.ItemPedido
                    .Where(p => p.PizzaId == id)
                    .ToListAsync();

                // Pega todos os PedidoIds únicos
                var pedidosIds = itensPedidos
                    .Select(i => i.PedidoId)
                    .Distinct()
                    .ToList();

                // Busca todos os pedidos de uma vez
                var pedidos = await _context.Pedido
                    .Where(p => pedidosIds.Contains(p.Id))
                    .Include(p => p.Itens)
                    .ToListAsync();

                // Remove apenas pedidos que ficariam vazios
                if(pedidos != null)
                {
                    foreach (var pedido in pedidos)
                    {
                        var totalItens = pedido.Itens.Count;
                        var itensDaPizza = pedido.Itens.Count(i => i.PizzaId == id);

                        if (totalItens == itensDaPizza)
                        {
                            _context.Pedido.Remove(pedido);
                        }
                    }
                }

                // Remove os itens da pizza
                if(itensPedidos != null)
                    _context.ItemPedido.RemoveRange(itensPedidos);

                // Remove a pizza
                _context.Pizza.Remove(pizza);

                await _context.SaveChangesAsync();

                serviceResponse.Dados = "Pizza removida com sucesso";
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = ex.Message;
            }

            return serviceResponse;
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

        public async Task<ServiceResponse<PizzaResponseDto>> GetPizzaById(int id)
        {
            ServiceResponse<PizzaResponseDto> serviceResponse = new();

            try
            {
                var pizza = await _context.Pizza.FirstOrDefaultAsync(p => p.Id == id) ?? throw new Exception("Dados não encontrados.");

                var pizzaResponse = new PizzaResponseDto
                {
                    Id = pizza.Id,
                    Nome = pizza.Nome,
                    Preco =pizza.Preco
                };

                serviceResponse.Dados = pizzaResponse;                
            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<PizzaResponseDto>> UpdatePizza(PizzaUpdateDto dto)
        {
            ServiceResponse<PizzaResponseDto> serviceResponse = new();

            try
            {
                var pizza = await _context.Pizza.FirstOrDefaultAsync(c => c.Id == dto.Id) ?? throw new Exception("Dados vazios. Tente novamente.");

                // Atualiza os dados
                pizza.Preco = dto.Preco;
                

                await _context.SaveChangesAsync();

                // Mapeia para DTO de resposta
                serviceResponse.Dados = new PizzaResponseDto
                {
                    Id = pizza.Id,
                    Preco = pizza.Preco
                };
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = ex.Message;
            }

            return serviceResponse;
        }
    }
}