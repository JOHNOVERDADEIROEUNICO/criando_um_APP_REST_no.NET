using ContosoPizza.Models;
using ContosoPizza.Services.Interfaces;

namespace ContosoPizza.Services.Implementations
{
    public class PagamentoService : IPagamentoService
    {
        public Task<ServiceResponse<List<Pagamento>>> CreatePagamento(Pagamento newPagamento)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Pagamento>>> DeletePagamento(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Pagamento>>> GetPagamento()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Pagamento>>> UpdatePagemento(Pagamento updatePagemento)
        {
            throw new NotImplementedException();
        }
    }
}