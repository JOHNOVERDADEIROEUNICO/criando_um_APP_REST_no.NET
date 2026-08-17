using System.ComponentModel.DataAnnotations;

namespace ContosoPizza.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public List<Pedido> Pedidos { get; set; } = new();

    }
}