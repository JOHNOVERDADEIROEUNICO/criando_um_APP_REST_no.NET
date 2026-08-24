using System.Security.Cryptography;
using ContosoPizza.DTOs.ItemPedido;
using ContosoPizza.Enum;

namespace ContosoPizza.DTOs.Pedido
{
    public class PedidoResponseDto
    {
        public int Id { get; set; }

        public int? UsuarioId { get; set; }

        public string Data {get; set;} = string.Empty;

        public decimal Total { get; set; }

        public TipoEnum Tipo { get; set; }

        public StatusEnum Status { get; set; } 

        public List<ItemPedidoResponseDto> Itens {get; set;} = new();
    }
}