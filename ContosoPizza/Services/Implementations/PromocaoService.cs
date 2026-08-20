using ContosoPizza.Models;
using ContosoPizza.Services.Interfaces;

namespace ContosoPizza.Services.Implementations
{
    public class PromocaoService : IPromocaoService
    {
        public Task<ServiceResponse<List<Promocao>>> CreatePromocao(Promocao newPromocao)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Promocao>>> DeletePromocao(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Promocao>>> GetPromocao()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Promocao>> GetPromocaoById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Promocao>>> InativaPromocao(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Promocao>>> UpdatePromocao(Promocao updatePromocao)
        {
            throw new NotImplementedException();
        }
    }
}