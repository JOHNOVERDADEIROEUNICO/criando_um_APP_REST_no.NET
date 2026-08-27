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

        public async Task<ServiceResponse<List<PromocaoResponseDto>>> CreatePromocao(PromocaoCreateDto dto)
        {
            ServiceResponse<List<PromocaoResponseDto>> serviceResponse = new ServiceResponse<List<PromocaoResponseDto>>();

            try
            {
                var pizza = await _context.Pizza.FirstOrDefaultAsync(i => i.Id == dto.IdPizza);

                if(pizza == null)
                    throw new Exception("Pizza não encontrada. Tente novamente");

                if(dto.Desconto <= 0 || dto.Desconto >= 1)
                    throw new Exception("Valor inválido, Tente novamente.");

                var promocao = new Promocao
                {
                    Descricao = dto.Descricao,
                    Desconto = dto.Desconto,
                    Ativa = false,
                    ApenasParaCadastrados = false,
                    PizzaId = pizza.Id
                };

                _context.Promocao.Add(promocao);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = await _context.Promocao.Select(i => new PromocaoResponseDto
                {
                    Id = i.Id,
                    Descricao = i.Descricao,
                    Desconto = i.Desconto
                }).ToListAsync();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
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