using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Padrao")));

var app = builder.Build();


app.UseDefaultFiles();
app.UseStaticFiles();


app.MapGet("/api", () => Results.Ok(new
{
    mensagem = "API de Álbuns do Radiohead no ar!",
    status = "Online"
}));

// listar
app.MapGet("/api/albuns", async (AppDbContext db) =>
{
    return Results.Ok(await db.Albuns.ToListAsync());
});

// buscar por id
app.MapGet("/api/albuns/{id:int}", async (int id, AppDbContext db) =>
{
    var album = await db.Albuns.FindAsync(id);

    return album is null
        ? Results.NotFound(new { mensagem = $"Álbum com ID {id} não encontrado." })
        : Results.Ok(album);
});

// cadastrar
app.MapPost("/api/albuns", async (AlbumEntradaDto dados, AppDbContext db) =>
{
    var novoAlbum = new Album
    {
        Titulo = dados.Titulo,
        AnoLancamento = dados.AnoLancamento,
        NumeroFaixas = dados.NumeroFaixas
    };

    db.Albuns.Add(novoAlbum);
    await db.SaveChangesAsync();

    return Results.Created($"/api/albuns/{novoAlbum.Id}", novoAlbum);
});

// atualizar
app.MapPut("/api/albuns/{id:int}", async (int id, AlbumEntradaDto dados, AppDbContext db) =>
{
    var album = await db.Albuns.FindAsync(id);
    if (album is null)
    {
        return Results.NotFound(new { mensagem = $"Álbum com ID {id} não encontrado." });
    }

    album.Titulo = dados.Titulo;
    album.AnoLancamento = dados.AnoLancamento;
    album.NumeroFaixas = dados.NumeroFaixas;

    await db.SaveChangesAsync();

    return Results.Ok(album);
});

// remover
app.MapDelete("/api/albuns/{id:int}", async (int id, AppDbContext db) =>
{
    var album = await db.Albuns.FindAsync(id);
    if (album is null)
    {
        return Results.NotFound(new { mensagem = $"Álbum com ID {id} não encontrado." });
    }

    db.Albuns.Remove(album);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();

record AlbumEntradaDto(string Titulo, int AnoLancamento, int NumeroFaixas);
