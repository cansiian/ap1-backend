using ApiAlbuns.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAlbuns.Data;

public class AppDbContext : DbContext

{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Album> Albuns => Set<Album>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Album>().HasData(
            new Album { Id = 1, Titulo = "OK Computer", AnoLancamento = 1997, NumeroFaixas = 12 },
            new Album { Id = 2, Titulo = "Kid A", AnoLancamento = 2000, NumeroFaixas = 10 },
            new Album { Id = 3, Titulo = "In Rainbows", AnoLancamento = 2007, NumeroFaixas = 10 }
        );
    }
}
