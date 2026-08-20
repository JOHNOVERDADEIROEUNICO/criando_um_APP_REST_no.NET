using ContosoPizza.Models;
using ContosoPizza.Services.Interfaces;

namespace ContosoPizza.Services.Implementations
{
    public class ClienteService : IClienteService
    {
        public Task<ServiceResponse<List<Clientes>>> CreateClientes(Clientes newCliente)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Clientes>>> DeleteClientes(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Clientes>> GetClienteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Clientes>>> GetClientes()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Clientes>>> UpdateClientes(Clientes updateCliente)
        {
            throw new NotImplementedException();
        }
    }
}