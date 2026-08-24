using System.Collections.Immutable;
using ContosoPizza.DataContext;
using ContosoPizza.DTOs.ItemPedido;
using ContosoPizza.DTOs.Pedido;
using ContosoPizza.Models;
using ContosoPizza.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services.Implementations
{
    public class PedidoService : IPedidoService
    {
        private readonly ApplicationDbContext _context;

        public PedidoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<ServiceResponse<List<Pedido>>> CreatePedido(Pedido newPedido)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Pedido>>> DeletePedido(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<PedidoResponseDto>>> GetPedido()
        {
            ServiceResponse<List<PedidoResponseDto>> serviceResponse = new ServiceResponse<List<PedidoResponseDto>>();

            try
            {
                var pedidos = await _context.Pedido
                    .Include(p => p.Itens)
                    .ThenInclude(i => i.Pizza)
                    .Include(i => i.Pagamento)
                    .ToListAsync();

                var pedidosDto = pedidos.Select(i => new PedidoResponseDto
                {
                    Id = i.Id,
                    UsuarioId = i.UsuarioId,
                    Data = i.Data.ToString("dd/MM/yyyy HH:mm"),
                    Total = i.Total,
                    
                    Itens = i.Itens.Select(p => new ItemPedidoResponseDto
                    {
                        Id = p.Id,
                        PizzaId = p.PizzaId,
                        NomePizza = p.Pizza!.Nome,
                        Quantidade = p.Quantidade

                    }).ToList(),

                    Tipo = i.Pagamento!.Tipo,
                    Status = i.Pagamento!.Status

                }).ToList();

                serviceResponse.Dados = pedidosDto;

                if(pedidosDto.Count == 0)
                    serviceResponse.Mensagem = "Nenhum Dado Registrado.";
            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public Task<ServiceResponse<Pedido>> GetPedidoById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Pedido>>> UpdatePedido(Pedido updatePedido)
        {
            throw new NotImplementedException();
        }
    }
}