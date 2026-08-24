namespace ContosoPizza.DTOs.Promocao
{
    public class PromocaoResponseDto
    {
        public int Id { get; set; }

        public string Descricao { get; set; } = string.Empty;

        public decimal Desconto { get; set; }

        public bool Ativa { get; set; }
    }
}