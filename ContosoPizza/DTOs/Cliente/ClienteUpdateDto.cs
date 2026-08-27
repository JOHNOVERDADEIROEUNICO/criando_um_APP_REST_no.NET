namespace ContosoPizza.DTOs.Cliente
{
    
    public class ClienteUpdateDto
    {
        public int Id {get; set;}

        public string Nome {get; set;} = string.Empty;

        public string Email {get; set;} = string.Empty;
    }
}