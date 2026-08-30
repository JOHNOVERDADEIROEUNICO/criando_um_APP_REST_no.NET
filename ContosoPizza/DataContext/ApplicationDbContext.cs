using Microsoft.EntityFrameworkCore;
using ContosoPizza.Models;

namespace ContosoPizza.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        // Esta linha abaixo onde definimos o construtor é de extrema importância, e sempre será utilizada para fazer conexão com o banco de dados.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

    //Para o caso de criar a tabela usamos o DbSet, ele também funciona se caso a tabela já existir, porém fique atento ao nome do objeto que deve ser indentico ao da tabela. OBS: A grande condição para que um model se concte com uma tabela, é de que o model tenha exatamente os mesmos paraemtros que as colunas da tabela, porém também é importante ter o nome extato da tabela sendo igual ao nome do model, pois se houver duas ou mais tabelas com os mesmos parametros, então obviamente teremos um erro. O DbSet também é essencial para quando formos construir o service, observe o código do service e veja que os objetos definidos são usados para fazer alterações ou puxar os dados das tabelas.
    
        public DbSet<Clientes> Clientes {get; set;}
        public DbSet<ItemPedido> ItemPedido {get; set;}
        public DbSet<Pedido> Pedido {get; set;}
        public DbSet<Pagamento> Pagamento {get; set;}
        public DbSet<Pizza> Pizza {get; set;}
        public DbSet<Promocao> Promocao {get; set;}
    

    //O model Build é menos moderno que o DbSet, porém ele permite que editemos e construamos os models exatamente igual a tabela de forma manual, e ainda faz com que sejamos capazes de editar caso a tabela e suas colunas diferenciem em nome da classe model e seus parametros assim indicando perfeitamente onde cada coisa se encaixa. Além disso, ele é melhor para mapear um banco legado (Banco já existete que somente vamos consumir os dados, ou seja que outro sistema cuida). o exemplo completo do Model Build com essas edições está em PDF na parte 3 da pasta explicações, aqui como nossa classe e seus parametros são indenticos em tipo e nome, logo não se faz necessário digitar tanto código assim. No fim se for criar pela primeira vez, prefira o DbSet, como eu fui fazendo acabei preferindo por deixar nele.
    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>(); //.ToTable("Clientes");  (Se caso a tabela possuir um nome diferente da classe model.)

            modelBuilder.Entity<ItemPedido>();

            modelBuilder.Entity<Pagamento>();

            modelBuilder.Entity<Pedido>();

            modelBuilder.Entity<Pizza>();

            modelBuilder.Entity<Promocao>();

            base.OnModelCreating(modelBuilder);
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cliente -> Pedido (1:N)
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Cliente)
                .WithMany(c => c.Pedidos)
                .HasForeignKey(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            // Pedido -> ItemPedido (1:N)
            modelBuilder.Entity<ItemPedido>()
                .HasOne(i => i.Pedido)
                .WithMany(p => p.Itens)
                .HasForeignKey(i => i.PedidoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Pedido -> Pagamento (1:1)
            modelBuilder.Entity<Pagamento>()
                .HasOne(p => p.Pedido)
                .WithOne(ped => ped.Pagamento)
                .HasForeignKey<Pagamento>(p => p.PedidoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ItemPedido>()
                .HasOne(i => i.Pizza)
                .WithMany(p => p.Itens)
                .HasForeignKey(i => i.PizzaId)
                .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
        }
        
    }
}