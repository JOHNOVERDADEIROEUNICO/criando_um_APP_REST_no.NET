using ContosoPizza.Models;
using ContosoPizza.Services.Interfaces;
using ContosoPizza.DataContext;
using ContosoPizza.DTOs.Cliente;
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

        public async Task<ServiceResponse<List<Clientes>>> CreateClientes(ClienteCreateDto dto)
        {
            ServiceResponse<List<Clientes>> serviceResponse = new ServiceResponse<List<Clientes>>();

            try
            {
                if(string.IsNullOrWhiteSpace(dto.Nome) || string.IsNullOrWhiteSpace(dto.Email))
                {
                    serviceResponse.Dados = null;

                    serviceResponse.Mensagem =  "Nome ou Email são obrigatórios.";

                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                var cliente = new Clientes
                {
                    Nome = dto.Nome,
                    Email = dto.Email
                };

                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Clientes.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<string>> DeleteClientes(int id)
        {
            ServiceResponse<string> serviceResponse = new();

            try
            {
                var cliente = await _context.Clientes
                    .FirstOrDefaultAsync(c => c.Id == id) ?? throw new Exception("Cliente não encontrado.");

                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = "Cliente removido com sucesso";
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<ClienteResponseDto>> GetClienteById(int id)
        {
            ServiceResponse<ClienteResponseDto> serviceResponse = new();

            try
            {
                var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id) ?? throw new Exception("Dados não encontrados.");

                var clienteResponse = new ClienteResponseDto
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    Email = cliente.Email
                };

                serviceResponse.Dados = clienteResponse;                
            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ClienteResponseDto>>> GetClientes()
        {
            ServiceResponse<List<ClienteResponseDto>> serviceResponse = new ServiceResponse<List<ClienteResponseDto>>();

            try
            {
                var clientes = await _context.Clientes.ToListAsync();

                var clientesDto = clientes.Select(c => new ClienteResponseDto
                    {
                        Id = c.Id,
                        Nome = c.Nome,
                        Email = c.Email
                    }
                ).ToList();

                serviceResponse.Dados = clientesDto;
                
                if(clientes.Count == 0)
                    serviceResponse.Mensagem = "Nenhum Dado Registrado.";
            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<ClienteResponseDto>> UpdateClientes(ClienteUpdateDto dto)
        {
            ServiceResponse<ClienteResponseDto> serviceResponse = new();

            try
            {
                var cliente = await _context.Clientes
                    .FirstOrDefaultAsync(c => c.Id == dto.Id) ?? throw new Exception("Dados vazios. Tente novamente.");

                // Atualiza os dados
                cliente.Nome = dto.Nome;
                cliente.Email = dto.Email;

                await _context.SaveChangesAsync();

                // Mapeia para DTO de resposta
                serviceResponse.Dados = new ClienteResponseDto
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    Email = cliente.Email
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