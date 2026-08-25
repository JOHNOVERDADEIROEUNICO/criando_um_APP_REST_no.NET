using ContosoPizza.DTOs.ItemPedido;

namespace ContosoPizza.DTOs.Pedido
{
    public class PedidoCreateDto
    {
        public int? UsuarioId { get; set; }
        public List<ItemPedidoDto> Itens { get; set; } = new();
    }
}