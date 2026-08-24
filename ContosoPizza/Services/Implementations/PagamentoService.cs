using ContosoPizza.DataContext;
using ContosoPizza.DTOs.Pagamento;
using ContosoPizza.Models;
using ContosoPizza.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<ServiceResponse<List<PagamentoResponseDto>>> GetPagamento()
        {
            ServiceResponse<List<PagamentoResponseDto>> serviceResponse = new ServiceResponse<List<PagamentoResponseDto>>();

            try
            {
                var pagante = await _context.Pagamento.ToListAsync();

                var PaganteDto = pagante.Select(p => new PagamentoResponseDto
                {
                    Id = p.Id,
                    PedidoId = p.PedidoId,
                    Tipo = p.Tipo,
                    Status = p.Status
                }).ToList();

                serviceResponse.Dados = PaganteDto;
                
                if(PaganteDto.Count == 0)
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