using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Thomas.RG.DAL.Models;

namespace Thomas.RG.DAL
{
    public interface IApplicationDbContext
    {
        DbSet<Espion> Espions { get; set; }
        DbSet<Mission> Missions { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        IAsyncEnumerable<Espion> GetEspionsAsync();
    }
}
