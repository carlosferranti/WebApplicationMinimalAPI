
using Microsoft.EntityFrameworkCore;
using WebApplicationMinimalAPI.Contexto;
using WebApplicationMinimalAPI.Model;

var builder = WebApplication.CreateBuilder(args);

string stringConnection = "Password=zoinho;Persist Security Info=True;User ID=sa;Initial Catalog=MinimalAPI;Data Source=DESKTOP-9CA3VTP\\SQLEXPRESS;MultipleActiveResultSets = true";

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<Contexto>(options => options.UseSqlServer(stringConnection));

builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();

//app.MapGet("/", () => "Hello World!");

app.MapPost("AdicionarCategoria", async (Categoria categoria, Contexto contexto) =>
{
    contexto.Categoria.Add(categoria);

    await contexto.SaveChangesAsync();
});

app.MapPost("ExcluirCategoria/{id}", async (int id, Contexto contexto) =>
{
    var produtoExcluir = await contexto.Categoria.FirstOrDefaultAsync(p => p.Id == id);

    if (produtoExcluir != null)
    {
        contexto.Categoria.Remove(produtoExcluir);

        await contexto.SaveChangesAsync();
    }

});

app.MapPost("ListarCategoria", async (Contexto contexto) =>
{
    return await contexto.Categoria.ToListAsync();
});

app.MapPost("ObterCategoria/{id}", async (int id, Contexto contexto) =>
{
    return await contexto.Categoria.FirstOrDefaultAsync(p => p.Id == id);
});

app.UseSwaggerUI();
app.Run();
