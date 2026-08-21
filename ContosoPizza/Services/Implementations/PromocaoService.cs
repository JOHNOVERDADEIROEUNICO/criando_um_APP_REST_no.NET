using ContosoPizza.DataContext;
using ContosoPizza.Models;
using ContosoPizza.Services.Interfaces;

namespace ContosoPizza.Services.Implementations
{
    public class PromocaoService : IPromocaoService
    {
        private readonly ApplicationDbContext _context;

        public PromocaoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<ServiceResponse<List<Promocao>>> CreatePromocao(Promocao newPromocao)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Promocao>>> DeletePromocao(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<Promocao>>> GetPromocao()
        {
            ServiceResponse<List<Promocao>> serviceResponse = new ServiceResponse<List<Promocao>>();

            try
            {
                serviceResponse.Dados = _context.Promocao.ToList();
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