using ContosoPizza.DataContext;
using ContosoPizza.DTOs.Promocao;
using ContosoPizza.Models;
using ContosoPizza.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<ServiceResponse<List<PromocaoResponseDto>>> GetPromocao()
        {
            ServiceResponse<List<PromocaoResponseDto>> serviceResponse = new ServiceResponse<List<PromocaoResponseDto>>();

            try
            {
                var promocao = await _context.Promocao.ToListAsync();

                var promocaoDto = promocao.Select(p => new PromocaoResponseDto
                {
                    Id = p.Id,
                    Descricao = p.Descricao,
                    Desconto = p.Desconto,
                    Ativa = p.Ativa

                }).ToList();

                serviceResponse.Dados = promocaoDto;

                if(promocaoDto.Count == 0)
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