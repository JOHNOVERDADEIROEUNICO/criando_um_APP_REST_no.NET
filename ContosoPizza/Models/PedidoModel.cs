using System.ComponentModel.DataAnnotations;

namespace ContosoPizza.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        public int? UsuarioId { get; set; }

        public Clientes? Cliente { get; set; }

        public DateTime Data { get; set; } = DateTime.Now.ToLocalTime();

        public decimal Total { get; set; }

        public List<ItemPedido> Itens { get; set; } = new();

        public Pagamento? Pagamento { get; set; }
    }
}