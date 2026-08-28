using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ContosoPizza.Migrations;

namespace ContosoPizza.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        public int? UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]//Como o nome Usario ID não é indêntico ao nome da tabela, precisamos registrar como foreign Key para que o sistema reconheça.
        public Clientes? Cliente { get; set; }

        public DateTime Data { get; set; } = DateTime.Now.ToLocalTime();

        public decimal Total { get; set; }

        public List<ItemPedido> Itens { get; set; } = new();

        public Pagamento? Pagamento { get; set; }

        //Isso aqui se demonstrou ser desnecessário no fim.
        public int? IdPromocao {get; set;}

        public Promocao? Promocao {get; set;}
    }
}