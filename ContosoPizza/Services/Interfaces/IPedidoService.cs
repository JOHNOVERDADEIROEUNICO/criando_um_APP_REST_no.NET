using ContosoPizza.DTOs.Pedido;
using ContosoPizza.Models;

namespace ContosoPizza.Services.Interfaces
{
    public interface IPedidoService
    {
        Task<ServiceResponse<List<PedidoResponseDto>>> GetPedido();

        Task<ServiceResponse<List<Pedido>>> CreatePedido(Pedido newPedido);

        Task<ServiceResponse<Pedido>> GetPedidoById(int id);

        Task<ServiceResponse<List<Pedido>>> UpdatePedido(Pedido updatePedido);

        Task<ServiceResponse<List<Pedido>>> DeletePedido(int id);

    }
}