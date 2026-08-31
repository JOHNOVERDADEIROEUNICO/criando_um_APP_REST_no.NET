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
                    ApenasParaCadastrados = true,
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

        public async Task<ServiceResponse<string>> DeletePromocao(int id)
        {
            ServiceResponse<string> serviceResponse = new();

            try
            {
                var promocao = await _context.Promocao
                    .FirstOrDefaultAsync(p => p.Id == id) ?? throw new Exception("Nenhuma promoção encontrada.");

                _context.Promocao.Remove(promocao);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = "Promoção removida com sucesso";
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = ex.Message;
            }

            return serviceResponse;
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

        public async Task<ServiceResponse<PromocaoResponseDto>> GetPromocaoById(int id)
        {
            ServiceResponse<PromocaoResponseDto> serviceResponse = new();

            try
            {
                var promocao = await _context.Promocao.FirstOrDefaultAsync(p => p.Id == id) ?? throw new Exception("Dados não encontrados.");

                var promocaoResponse = new PromocaoResponseDto
                {
                    Id = promocao.Id,
                    Descricao = promocao.Descricao,
                    Desconto = promocao.Desconto,
                    Ativa = promocao.Ativa,
                    ApenasParaCadastrados = promocao.ApenasParaCadastrados
                };

                serviceResponse.Dados = promocaoResponse;                
            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public Task<ServiceResponse<List<Promocao>>> InativaPromocao(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<PromocaoResponseDto>> UpdatePromocao(PromocaoUpdateDto dto)
        {
            ServiceResponse<PromocaoResponseDto> serviceResponse = new();

            try
            {
                var promocao = await _context.Promocao
                .FirstOrDefaultAsync(p => p.Id == dto.Id) ?? throw new Exception("Dados vazios. Tente novamente.");
                
                if(dto.ApenasParaCadastrados == null || dto.Ativa == null || dto.Desconto <=0 || dto.Desconto >=1 || dto.Descricao == null)
                    throw new Exception("Algum dado está vazio, Tente Novamente.");

                promocao.Desconto = dto.Desconto;
                promocao.Descricao = dto.Descricao;

                if(dto.Ativa == "sim")
                    promocao.Ativa = true;

                else if(dto.Ativa == "não")
                    promocao.Ativa = false;

                if(dto.ApenasParaCadastrados == "sim")
                    promocao.ApenasParaCadastrados = true;

                else if(dto.ApenasParaCadastrados == "não")
                    promocao.ApenasParaCadastrados = false;

                await _context.SaveChangesAsync();

                serviceResponse.Dados = new PromocaoResponseDto
                {
                    Descricao = promocao.Descricao,
                    Desconto = promocao.Desconto,
                    Ativa = promocao.Ativa,
                    ApenasParaCadastrados = promocao.ApenasParaCadastrados
                };

            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = ex.Message;
            }

            return serviceResponse;
        }
    }
}