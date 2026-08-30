using System.ComponentModel.DataAnnotations;

namespace ContosoPizza.Models
{
    public class ItemPedido
    {
        [Key]
        public int Id { get; set; }

        public int PedidoId { get; set; }

        //Qunado a chave estrangeira tem a conjunção <nomeDaTabelaEstrangeira> + id e colocamos logo abaixo um parametro instanciado como sendo da classe da tabela estrangeira o ef core associa automaticamente sem precisaramos colocar um [foreignKey] .
        public Pedido? Pedido { get; set; }

        public int? PizzaId { get; set; }

        public Pizza? Pizza { get; set; }

        public int Quantidade { get; set; }

    }
}