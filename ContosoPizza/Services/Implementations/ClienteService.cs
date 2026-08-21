using ContosoPizza.Models;
using ContosoPizza.Services.Interfaces;
using ContosoPizza.DataContext;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services.Implementations
{
    public class ClienteService : IClienteService
    {
        private readonly ApplicationDbContext _context;

        public ClienteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Clientes>>> CreateClientes(Clientes newCliente)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<Clientes>>> DeleteClientes(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<Clientes>> GetClienteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<Clientes>>> GetClientes()
        {
            ServiceResponse<List<Clientes>> serviceResponse = new ServiceResponse<List<Clientes>>();

            try
            {
                serviceResponse.Dados = _context.Clientes.ToList();
                if(serviceResponse.Dados.Count == 0)
                    serviceResponse.Mensagem = "Nenhum Dado Registrado.";
            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Clientes>>> UpdateClientes(Clientes updateCliente)
        {
            throw new NotImplementedException();
        }
    }
}