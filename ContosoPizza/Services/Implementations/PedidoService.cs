using ContosoPizza.Models;
using ContosoPizza.Services.Interfaces;

namespace ContosoPizza.Services.Implementations
{
    public class PedidoService : IPedidoService
    {
        public Task<ServiceResponse<List<Pedido>>> CreatePedido(Pedido newPedido)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Pedido>>> DeletePedido(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Pedido>>> GetPedido()
        {
            throw new NotImplementedException();
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