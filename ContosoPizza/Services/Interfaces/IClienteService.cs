using ContosoPizza.Models;

namespace ContosoPizza.Services.Interfaces
{
    public interface IClienteService
    {
        Task<ServiceResponse<List<Clientes>>> GetClientes();

        Task<ServiceResponse<List<Clientes>>> CreateClientes(Clientes newCliente);

        Task<ServiceResponse<Clientes>> GetClienteById(int id);

        Task<ServiceResponse<List<Clientes>>> UpdateClientes(Clientes updateCliente);

        Task<ServiceResponse<List<Clientes>>> DeleteClientes(int id);
    }
}