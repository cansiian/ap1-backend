var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var albuns = new List<AlbumDto>
{
    new AlbumDto(1, "OK Computer", 1997, 12),
    new AlbumDto(2, "Kid A", 2000, 10),
    new AlbumDto(3, "In Rainbows", 2007, 10),
};

app.MapGet("/", () => Results.Ok(new 
{ 
    mensagem = "API de Álbuns do Radiohead no ar!", 
    status = "Online" 
}));

// listar
app.MapGet("/api/albuns", () =>
{
    return Results.Ok(albuns);
});

// busca por id
app.MapGet("/api/albuns/{id:int}", (int id) =>
{
    var album = albuns.FirstOrDefault(a => a.Id == id);
    if (album is null)
    {
        return Results.NotFound(new { mensagem = $"Álbum com ID {id} não encontrado." });
    }

    return Results.Ok(album);
});

// cadastrar
app.MapPost("/api/albuns", (AlbumEntradaDto dados) =>
{
    int proximoId = albuns.Count > 0 ? albuns.Max(a => a.Id) + 1 : 1;
    var novoAlbum = new AlbumDto(proximoId, dados.Titulo, dados.AnoLancamento, dados.NumeroFaixas);

    albuns.Add(novoAlbum);

    return Results.Created($"/api/albuns/{novoAlbum.Id}", novoAlbum);
});

// atualizar
app.MapPut("/api/albuns/{id:int}", (int id, AlbumEntradaDto dados) =>
{
    int indice = albuns.FindIndex(albumDaLista => albumDaLista.Id == id);
    if (indice == -1)
    {
        return Results.NotFound(new { mensagem = $"Álbum com ID {id} não encontrado." });
    }

    var albumAtualizado = new AlbumDto(id, dados.Titulo, dados.AnoLancamento, dados.NumeroFaixas);
    
    albuns[indice] = albumAtualizado;

    return Results.Ok(albumAtualizado);
});

// remover
app.MapDelete("/api/albuns/{id:int}", (int id) =>
{
    int indice = albuns.FindIndex(albumDaLista => albumDaLista.Id == id);
    if (indice == -1)
    {
        return Results.NotFound(new { mensagem = $"Álbum com ID {id} não encontrado." });
    }

    albuns.RemoveAt(indice);
    
    return Results.NoContent();
});

app.Run();

record AlbumDto(int Id, string Titulo, int AnoLancamento, int NumeroFaixas);
record AlbumEntradaDto(string Titulo, int AnoLancamento, int NumeroFaixas);