using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Album> Albuns => Set<Album>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Os 3 álbuns da AP1 entram na migration, então quem rodar
        // "dotnet ef database update" já recebe dados iniciais.
        // Opcional: apague este método se preferir começar com o banco vazio.
        modelBuilder.Entity<Album>().HasData(
            new Album { Id = 1, Titulo = "OK Computer", AnoLancamento = 1997, NumeroFaixas = 12 },
            new Album { Id = 2, Titulo = "Kid A", AnoLancamento = 2000, NumeroFaixas = 10 },
            new Album { Id = 3, Titulo = "In Rainbows", AnoLancamento = 2007, NumeroFaixas = 10 }
        );
    }
}
