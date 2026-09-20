using System.ComponentModel.DataAnnotations;
using ContosoPizza.Enum;

namespace ContosoPizza.Models
{

    public class Pizza
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        [Range(1, 1000, ErrorMessage = "O preço deve ser no mínimo 1")]
        public decimal Preco { get; set; }

        public List<ItemPedido> Itens { get; set; } = new();

    }

}