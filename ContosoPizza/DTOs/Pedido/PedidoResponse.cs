using System.Security.Cryptography;
using ContosoPizza.DTOs.ItemPedido;
using ContosoPizza.DTOs.Pagamento;
using ContosoPizza.Enum;

namespace ContosoPizza.DTOs.Pedido
{
    public class PedidoResponseDto
    {
        public int Id { get; set; }

        public int? UsuarioId { get; set; }

        public DateTime Data {get; set;}

        public decimal Total { get; set; }

    

        public List<ItemPedidoResponseDto> Itens {get; set;} = new();

        public PagamentoResponseDto Pagamento {get; set;} = new();
    }
}