namespace ContosoPizza.DTOs.ItemPedido
{
    public class ItemPedidoResponseDto
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int PizzaId { get; set; }
        public string NomePizza { get; set; } = string.Empty;
        public decimal Preco {get; set;}
        public int Quantidade { get; set; }
    }
}