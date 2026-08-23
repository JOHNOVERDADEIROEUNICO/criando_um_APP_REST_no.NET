using ContosoPizza.Models;
using ContosoPizza.DTOs.Cliente;

namespace ContosoPizza.Services.Interfaces
{
    public interface IClienteService
    {
        Task<ServiceResponse<List<ClienteResponseDto>>> GetClientes();

        Task<ServiceResponse<List<Clientes>>> CreateClientes(ClienteCreateDto dto);

        Task<ServiceResponse<Clientes>> GetClienteById(int id);

        Task<ServiceResponse<List<Clientes>>> UpdateClientes(Clientes updateCliente);

        Task<ServiceResponse<List<Clientes>>> DeleteClientes(int id);
    }
}