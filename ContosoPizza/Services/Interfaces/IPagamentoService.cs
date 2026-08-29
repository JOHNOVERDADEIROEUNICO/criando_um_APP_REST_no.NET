using ContosoPizza.DTOs.Pagamento;
using ContosoPizza.Models;

namespace ContosoPizza.Services.Interfaces
{
    public interface IPagamentoService
    {
        Task<ServiceResponse<List<PagamentoResponseDto>>> GetPagamento();

        Task<ServiceResponse<List<Pagamento>>> CreatePagamento(Pagamento newPagamento);

        Task<ServiceResponse<string>> ConfirmarPagemento(int pedidoId);

        Task<ServiceResponse<List<Pagamento>>> DeletePagamento(int id);
    }
}