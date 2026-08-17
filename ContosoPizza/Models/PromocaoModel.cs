using System.ComponentModel.DataAnnotations;

namespace ContosoPizza.Models
{
    
    public class Promocao
    {
        [Key]
        public int Id { get; set; }

        public string Descricao { get; set; }

        public decimal Desconto { get; set; }

        public bool Ativa { get; set; }

        public bool ApenasParaCadastrados { get; set; }

    }
}