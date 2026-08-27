namespace ContosoPizza.DTOs.Promocao
{
    public class PromocaoCreateDto
    {
        public string Descricao { get; set; } = string.Empty;

        public decimal Desconto { get; set; }

        public int IdPizza {get; set;}
    }
}