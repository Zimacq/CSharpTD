using Microsoft.EntityFrameworkCore;
using Thomas.RG.DAL.Models;

public interface IApplicationDbContext
{
    DbSet<Espion> Espions { get; set; }
    DbSet<Mission> Missions { get; set; }

    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Espion> Espions { get; set; }
    public DbSet<Mission> Missions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = "server=localhost;port=3306;database=dbcontext3;user=root;password=;";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }

    public async IAsyncEnumerable<Espion> GetEspionsAsync()
    {
        foreach (var espion in Espions)
        {
            yield return await Task.FromResult(espion);
        }
    }
}
