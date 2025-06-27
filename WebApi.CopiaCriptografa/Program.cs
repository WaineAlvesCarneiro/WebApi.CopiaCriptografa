using Microsoft.EntityFrameworkCore;
using WebApi.CopiaCriptografa.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configuração do DbContext
builder.Services.AddDbContext<DbContextLancCripto>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DbContextLancCripto")
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // mesma funcionalidade do Startup.cs
}

app.UseHttpsRedirection();

app.UseRouting(); // opcional mas equivalente ao Startup.cs

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
