using ContosoPizza.DataContext;
using ContosoPizza.DTOs.ItemPedido;
using ContosoPizza.Models;
using ContosoPizza.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services.Implementations
{
    public class ItemPedidoService : IItemPedidoService
    {
        private readonly ApplicationDbContext _context;

        public ItemPedidoService(ApplicationDbContext context)
        {
            _context = context;
        }

        //O item pedido não precisa de um post, porque o post pedido já será capaz de jogar para dentro da tabela os parametros.
        public Task<ServiceResponse<List<ItemPedido>>> CreateItemPedido(ItemPedido newItemPedido)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<ItemPedido>>> DeleteItemPedido(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<ItemPedidoResponseDto>>> GetItemPedido()
        {
            ServiceResponse<List<ItemPedidoResponseDto>> serviceResponse = new();

            try
            {
                var itens = await _context.ItemPedido
                    .Include(i => i.Pizza)
                    .ToListAsync();

                var itensDto = itens.Select(i => new ItemPedidoResponseDto
                {
                    Id = i.Id,
                    PedidoId = i.PedidoId,
                    PizzaId = i.PizzaId,
                    NomePizza = i.Pizza!.Nome,
                    Quantidade = i.Quantidade
                }).ToList();

                serviceResponse.Dados = itensDto;

                if(itensDto.Count == 0)
                    serviceResponse.Mensagem = "Nenhum Dado Registrado.";
            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public Task<ServiceResponse<ItemPedido>> GetItemPedidoById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<ItemPedido>>> UpdateItemPedido(ItemPedido updateItemPedido)
        {
            throw new NotImplementedException();
        }
    }
}