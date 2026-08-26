using ContosoPizza.DTOs.ItemPedido;
using ContosoPizza.Enum;

namespace ContosoPizza.DTOs.Pedido
{
    public class PedidoCreateDto
    {
        public int? UsuarioId { get; set; }
        public List<ItemPedidoDto> Itens { get; set; } = new();

        public TipoEnum TipoPagamento {get; set;}
    }
}