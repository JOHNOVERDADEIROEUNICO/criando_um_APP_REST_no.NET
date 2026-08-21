using ContosoPizza.DataContext;
using ContosoPizza.Models;
using ContosoPizza.Services.Interfaces;

namespace ContosoPizza.Services.Implementations
{
    public class ItemPedidoService : IItemPedidoService
    {
        private readonly ApplicationDbContext _context;

        public ItemPedidoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<ServiceResponse<List<ItemPedido>>> CreateItemPedido(ItemPedido newItemPedido)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<ItemPedido>>> DeleteItemPedido(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<ItemPedido>>> GetItemPedido()
        {
            ServiceResponse<List<ItemPedido>> serviceResponse = new ServiceResponse<List<ItemPedido>>();

            try
            {
                serviceResponse.Dados = _context.ItemPedido.ToList();
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