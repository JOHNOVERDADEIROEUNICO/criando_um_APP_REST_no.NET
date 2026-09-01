using System.Collections.Immutable;

using ContosoPizza.DataContext;
using ContosoPizza.DTOs.ItemPedido;
using ContosoPizza.DTOs.Pagamento;
using ContosoPizza.DTOs.Pedido;

using ContosoPizza.Enum;
using ContosoPizza.Models;
using ContosoPizza.Services.Interfaces;
using ContosoPizza.Helpers;

using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services.Implementations
{
    public class PedidoService : IPedidoService
    {
        private readonly ApplicationDbContext _context;

        public PedidoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<PedidoResponseDto>>> CreatePedido(PedidoCreateDto dto)
        {
            ServiceResponse<List<PedidoResponseDto>> serviceResponse = new ServiceResponse<List<PedidoResponseDto>>();

            decimal total = 0;

            var itens = new List<ItemPedido>();

            try
            {
                if(dto.Itens == null || dto.Itens.Any())
                    throw new Exception("Pedido deve ter ao menos um item.");

                foreach (var item in dto.Itens)
                {
                    var pizza = await _context.Pizza.FindAsync(item.PizzaId) ?? throw new Exception("Nenhuma pizza encontrada. Tente novamente");

                    var promocao = await _context.Promocao.FindAsync(item.PizzaId);

                    if(promocao == null)
                        total += pizza.Preco * item.Quantidade;

                    else if(dto.UsuarioId == null || promocao!.Ativa == false)
                        total += pizza.Preco * item.Quantidade;

                    else
                    {
                        if(promocao.Ativa == false)
                            total += pizza.Preco * item.Quantidade;

                        total += (pizza.Preco - (pizza.Preco * promocao.Desconto)) * item.Quantidade;
                    }

                    itens.Add(new ItemPedido
                    {
                        PizzaId = item.PizzaId,
                        Quantidade = item.Quantidade

                    });
                }

                var pagamento = new Pagamento
                {
                    Tipo = dto.TipoPagamento,
                    Status = StatusEnum.Pendente //(StatusEnum)0

                };

                if(dto.TipoPagamento == TipoEnum.Pix)
                {
                    pagamento.CodigoPix = PixHelper.GerarCodigoPix(
                        chave: "seuemail@pix.com", //Pode vir do banco depois
                        valor: total,
                        nome: "Contoso Pizzaria",
                        cidade: "GOIANIA"

                    );

                }

                var pedido = new Pedido
                {
                    UsuarioId = dto.UsuarioId,
                    Data = DateTime.Now,
                    Itens = itens,
                    Total = total,
                    Pagamento = pagamento
                
                };

                _context.Pedido.Add(pedido);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = await _context.Pedido
                    .Include(p => p.Itens)
                        .ThenInclude(i => i.Pizza)
                    .Include(p => p.Pagamento)
                    .Select(p => new PedidoResponseDto
                    {
                        Id = p.Id,
                        UsuarioId = p.UsuarioId,
                        Data = p.Data,
                        Total = p.Total,

                        Itens = p.Itens.Select(i => new ItemPedidoResponseDto
                        {
                            PizzaId = i.PizzaId,
                            NomePizza = i.Pizza!.Nome,
                            Quantidade = i.Quantidade

                        }).ToList(),

                        Pagamento = new PagamentoResponseDto
                        {
                            Tipo = p.Pagamento!.Tipo,
                            Status = p.Pagamento.Status,
                            CodigoPix = p.Pagamento.CodigoPix!

                        }
                    }).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;

            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<string>> DeletePedido(int id)
        {
            ServiceResponse<string> serviceResponse = new();

            try
            {
                var pedido = await _context.Pedido
                    .FirstOrDefaultAsync(p => p.Id == id) ?? throw new Exception("Nenhum pedido encontrado com este id.");

                _context.Pedido.Remove(pedido);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = "Pedido cancelado.";
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PedidoResponseDto>>> GetPedido()
        {
            ServiceResponse<List<PedidoResponseDto>> serviceResponse = new ServiceResponse<List<PedidoResponseDto>>();

            try
            {
                var pedidos = await _context.Pedido
                    .Include(p => p.Itens)
                        .ThenInclude(i => i.Pizza)
                    .Include(i => i.Pagamento)
                    .ToListAsync();

                var pedidosDto = pedidos.Select(i => new PedidoResponseDto
                {
                    Id = i.Id,
                    UsuarioId = i.UsuarioId,
                    Data = i.Data,
                    Total = i.Total,
                    
                    Itens = i.Itens.Select(p => new ItemPedidoResponseDto
                    {
                        PizzaId = p.PizzaId,
                        NomePizza = p.Pizza!.Nome,
                        Quantidade = p.Quantidade

                    }).ToList(),

                    Pagamento = new PagamentoResponseDto
                    {
                        Tipo = i.Pagamento!.Tipo,
                        Status = i.Pagamento!.Status
                    }

                }).ToList();

                serviceResponse.Dados = pedidosDto;

                if(pedidosDto.Count == 0)
                    serviceResponse.Mensagem = "Nenhum Dado Registrado.";
            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<PedidoResponseDto>> GetPedidoById(int id)
        {
            ServiceResponse<PedidoResponseDto> serviceResponse = new();

            try
            {
                var pedido = await _context.Pedido
                    .Include(p => p.Itens)
                        .ThenInclude(p => p.Pizza)
                    .Include(p => p.Pagamento)
                    .FirstOrDefaultAsync(c => c.Id == id) ?? throw new Exception("Dados não encontrados.");

                var itens = pedido.Itens.ToList();

                var pedidoResponse = new PedidoResponseDto
                {
                    Id = pedido.Id,
                    UsuarioId = pedido.UsuarioId,
                    Data = pedido.Data,
                    Total = pedido.Total,

                    Itens = itens.Select(i => new ItemPedidoResponseDto
                    {
                        PizzaId = i.PizzaId,
                        NomePizza = i.Pizza!.Nome,
                        Quantidade = i.Quantidade

                    }).ToList(),

                    Pagamento = new PagamentoResponseDto
                    {
                        Tipo = pedido.Pagamento!.Tipo,
                        Status = pedido.Pagamento.Status
                    }
                };

                serviceResponse.Dados = pedidoResponse;                
            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public Task<ServiceResponse<List<Pedido>>> UpdatePedido(Pedido updatePedido)
        {
            throw new NotImplementedException();
        }
    }
}