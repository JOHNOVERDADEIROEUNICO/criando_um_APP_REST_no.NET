namespace ContosoPizza.DTOs.Promocao
{
    public class PromocaoUpdateDto
    {
        public int Id {get; set;}
        public string Descricao { get; set; } = string.Empty;

        public decimal Desconto { get; set; }

        public string Ativa { get; set; } = string.Empty;

        public string ApenasParaCadastrados { get; set; } = string.Empty;
    }
}