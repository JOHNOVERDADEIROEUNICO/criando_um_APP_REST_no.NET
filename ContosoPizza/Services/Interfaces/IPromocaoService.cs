using ContosoPizza.DTOs.Promocao;
using ContosoPizza.Models;

namespace ContosoPizza.Services.Interfaces
{
    public interface IPromocaoService
    {
        Task<ServiceResponse<List<PromocaoResponseDto>>> GetPromocao();

        Task<ServiceResponse<List<PromocaoResponseDto>>> CreatePromocao(PromocaoCreateDto dto);

        Task<ServiceResponse<Promocao>> GetPromocaoById(int id);

        Task<ServiceResponse<List<Promocao>>> UpdatePromocao(Promocao updatePromocao);

        Task<ServiceResponse<List<Promocao>>> DeletePromocao(int id);

        Task<ServiceResponse<List<Promocao>>> InativaPromocao(int id);
    }
}