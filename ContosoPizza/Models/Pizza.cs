using System.ComponentModel.DataAnnotations;

namespace ContosoPizza.Models;

public class Pizza
{
    public int Id { get; private set; }

    public string Nome { get; private set; } = string.Empty;

    public decimal Preco { get; private set; }

    public List<ItemPedido> Itens { get; private set; } = new();

    // Construtor para EF
    private Pizza() { }

    public Pizza(string nome, decimal preco)
    {
        AlterarNome(nome);
        AlterarPreco(preco);
    }

    public void AlterarNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new Exception("Nome da pizza inválido");

        Nome = nome;
    }

    public void AlterarPreco(decimal preco)
    {
        if (preco <= 0)
            throw new Exception("Preço deve ser maior que zero");

        Preco = preco;
    }
}

public class Cliente
{
    public int Id { get; private set; }

    public string Nome { get; private set; } = string.Empty;

    public string Email { get; private set; } = string.Empty;

    public List<Pedido> Pedidos { get; private set; } = new();

    private Cliente() { }

    public Cliente(string nome, string email)
    {
        AlterarNome(nome);
        AlterarEmail(email);
    }

    public void AlterarNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new Exception("Nome inválido");

        Nome = nome;
    }

    public void AlterarEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            throw new Exception("Email inválido");

        Email = email;
    }
}

public class Pedido
{
    public int Id { get; private set; }

    public int? UsuarioId { get; private set; }

    public Cliente? Cliente { get; private set; }

    public DateTime Data { get; private set; }

    public decimal Total { get; private set; }

    public List<ItemPedido> Itens { get; private set; } = new();

    public Pagamento? Pagamento { get; private set; }

    private Pedido() { }

    public Pedido(Cliente? cliente = null)
    {
        Data = DateTime.Now;

        if (cliente != null)
        {
            Cliente = cliente;
            UsuarioId = cliente.Id;
        }
    }

    public void AdicionarItem(Pizza pizza, int quantidade)
    {
        if (quantidade <= 0)
            throw new Exception("Quantidade inválida");

        var item = new ItemPedido(this, pizza, quantidade);
        Itens.Add(item);

        RecalcularTotal();
    }

    public void RemoverItem(ItemPedido item)
    {
        Itens.Remove(item);
        RecalcularTotal();
    }

    private void RecalcularTotal()
    {
        Total = Itens.Sum(i => i.Subtotal());
    }

    public void DefinirPagamento(Pagamento pagamento)
    {
        Pagamento = pagamento;
    }
}

public class ItemPedido
{
    public int Id { get; private set; }

    public int PedidoId { get; private set; }

    public Pedido Pedido { get; private set; }

    public int PizzaId { get; private set; }

    public Pizza Pizza { get; private set; }

    public int Quantidade { get; private set; }

    private ItemPedido() { }

    public ItemPedido(Pedido pedido, Pizza pizza, int quantidade)
    {
        Pedido = pedido;
        PedidoId = pedido.Id;

        Pizza = pizza;
        PizzaId = pizza.Id;

        AlterarQuantidade(quantidade);
    }

    public void AlterarQuantidade(int quantidade)
    {
        if (quantidade <= 0)
            throw new Exception("Quantidade deve ser maior que zero");

        Quantidade = quantidade;
    }

    public decimal Subtotal()
    {
        return Quantidade * Pizza.Preco;
    }
}

public class Pagamento
{
    public int Id { get; private set; }

    public int PedidoId { get; private set; }

    public Pedido Pedido { get; private set; }

    public string Tipo { get; private set; } = string.Empty;

    public string Status { get; private set; } = "Pendente";

    public string? CodigoPix { get; private set; }

    private Pagamento() { }

    public Pagamento(Pedido pedido, string tipo)
    {
        Pedido = pedido;
        PedidoId = pedido.Id;

        DefinirTipo(tipo);
    }

    public void DefinirTipo(string tipo)
    {
        if (string.IsNullOrWhiteSpace(tipo))
            throw new Exception("Tipo de pagamento inválido");

        Tipo = tipo;
    }

    public void MarcarComoPago()
    {
        Status = "Pago";
    }

    public void MarcarComoCancelado()
    {
        Status = "Cancelado";
    }

    public void GerarPix(string codigo)
    {
        CodigoPix = codigo;
    }
}

public class Promocao
{
    public int Id { get; private set; }

    public string Descricao { get; private set; } = string.Empty;

    public decimal Desconto { get; private set; }

    public bool Ativa { get; private set; }

    public bool ApenasParaCadastrados { get; private set; }

    private Promocao() { }

    public Promocao(string descricao, decimal desconto, bool apenasParaCadastrados)
    {
        Descricao = descricao;
        DefinirDesconto(desconto);
        ApenasParaCadastrados = apenasParaCadastrados;
        Ativa = true;
    }

    public void DefinirDesconto(decimal desconto)
    {
        if (desconto <= 0 || desconto > 1)
            throw new Exception("Desconto deve estar entre 0 e 1 (ex: 0.1 = 10%)");

        Desconto = desconto;
    }

    public void Ativar() => Ativa = true;

    public void Desativar() => Ativa = false;
}