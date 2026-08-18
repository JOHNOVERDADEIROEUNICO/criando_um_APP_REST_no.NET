using System.ComponentModel.DataAnnotations;

namespace ContosoPizza.Models
{
    public class ItemPedido
    {
        [Key]
        public int Id { get; set; }

        public int PedidoId { get; set; }

        public Pedido? Pedido { get; set; }

        public int PizzaId { get; set; }

        public Pizza? Pizza { get; set; }

        public int Quantidade { get; set; }

    }
}