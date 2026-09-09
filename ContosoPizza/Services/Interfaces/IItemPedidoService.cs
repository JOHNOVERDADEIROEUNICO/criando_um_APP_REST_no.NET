using ContosoPizza.DTOs.ItemPedido;
using ContosoPizza.Models;

namespace ContosoPizza.Services.Interfaces
{
    public interface IItemPedidoService
    {
        Task<ServiceResponse<List<ItemPedidoResponseDto>>> GetItemPedido();
        
    }
}