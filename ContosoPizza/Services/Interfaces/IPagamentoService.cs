using ContosoPizza.Models;

namespace ContosoPizza.Services.Interfaces
{
    public interface IPagamentoService
    {
        Task<ServiceResponse<List<Pagamento>>> GetPagamento();

        Task<ServiceResponse<List<Pagamento>>> CreatePagamento(Pagamento newPagamento);

        Task<ServiceResponse<List<Pagamento>>> UpdatePagemento(Pagamento updatePagemento);

        Task<ServiceResponse<List<Pagamento>>> DeletePagamento(int id);
    }
}