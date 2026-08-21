using ContosoPizza.DataContext;
using ContosoPizza.Models;
using ContosoPizza.Services.Interfaces;

namespace ContosoPizza.Services.Implementations
{
    public class PagamentoService : IPagamentoService
    {
        private readonly ApplicationDbContext _context;

        public PagamentoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<ServiceResponse<List<Pagamento>>> CreatePagamento(Pagamento newPagamento)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Pagamento>>> DeletePagamento(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<Pagamento>>> GetPagamento()
        {
            ServiceResponse<List<Pagamento>> serviceResponse = new ServiceResponse<List<Pagamento>>();

            try
            {
                serviceResponse.Dados = _context.Pagamento.ToList();
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

        public Task<ServiceResponse<List<Pagamento>>> UpdatePagemento(Pagamento updatePagemento)
        {
            throw new NotImplementedException();
        }
    }
}