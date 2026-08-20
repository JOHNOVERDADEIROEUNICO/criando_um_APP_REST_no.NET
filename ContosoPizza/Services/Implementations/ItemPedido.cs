using ContosoPizza.Models;
using ContosoPizza.Services.Interfaces;

namespace ContosoPizza.Services.Implementations
{
    public class ItemPedidoService : IItemPedidoService
    {
        public Task<ServiceResponse<List<ItemPedido>>> CreateItemPedido(ItemPedido newItemPedido)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<ItemPedido>>> DeleteItemPedido(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<ItemPedido>>> GetItemPedido()
        {
            throw new NotImplementedException();
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