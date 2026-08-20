using ContosoPizza.Models;

namespace ContosoPizza.Services.Interfaces
{
    public interface IItemPedidoService
    {
        Task<ServiceResponse<List<ItemPedido>>> GetItemPedido();

        Task<ServiceResponse<List<ItemPedido>>> CreateItemPedido(ItemPedido newItemPedido);

        Task<ServiceResponse<ItemPedido>> GetItemPedidoById(int id);

        Task<ServiceResponse<List<ItemPedido>>> UpdateItemPedido(ItemPedido updateItemPedido);

        Task<ServiceResponse<List<ItemPedido>>> DeleteItemPedido(int id);
    }
}