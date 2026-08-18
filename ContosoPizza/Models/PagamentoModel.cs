using System.ComponentModel.DataAnnotations;
using ContosoPizza.Enum;

namespace ContosoPizza.Models
{
    public class Pagamento
    {
        [Key]
        public int Id { get; set; }

        public int PedidoId { get; set; }

        public Pedido? Pedido { get; set; }

        public TipoEnum Tipo { get; set; }

        public StatusEnum Status { get; set; } 

        public string? CodigoPix { get; set; }
    }
}