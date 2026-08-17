using System.ComponentModel.DataAnnotations;

namespace ContosoPizza.Models
{
    //O t entre o sinal de maior e menor significa que a classe ou objeto receberá tipos de dados genéricos
    public class ServiceResponse<T>
    {
        public T? Dados {get; set;}

        public string Mensagem {get; set;} = string.Empty;

        public bool Sucesso { get; set; } = true;
    }
}