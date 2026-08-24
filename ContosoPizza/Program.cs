using System.Text.Json.Serialization;
using ContosoPizza.DataContext;
using ContosoPizza.Services.Implementations;
using ContosoPizza.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5000); // HTTP
    options.ListenLocalhost(5001, listenOptions =>
    {
        listenOptions.UseHttps();
    });
});

//Esta linha faz o sistema entender que quando usarmos injeção de dependencia, a interface está conectada diretamente ao service, no caso você pode ver isso acontecendo no controller, onde usaremos a interface para conectar com as requisições http.
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IItemPedidoService, ItemPedidoService>();
builder.Services.AddScoped<IPagamentoService, PagamentoService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<IPizzaService, PizzaService>();
builder.Services.AddScoped<IPromocaoService, PromocaoService>();

//Faz com que nossos enums ao invészs de retornar numeros retornem as strings que estabelecemos.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(
        new JsonStringEnumConverter());
});

//Configurando o banco sql server:
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
