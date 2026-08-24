using ContosoPizza.Enum;

namespace ContosoPizza.DTOs.Pagamento
{
    public class PagamentoResponseDto
    {
        public int Id { get; set; }

        public int PedidoId { get; set; }

        public TipoEnum Tipo { get; set; }

        public StatusEnum Status { get; set; } 
    }
}