using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Thomas.RG.DAL.Models;

namespace Thomas.RG.DAL.Services
{
    public class EspionService : IEspionService
    {
        private readonly IApplicationDbContext _context;

        public EspionService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AjouterEspionAsync(string nom, string codeNom)
        {
            var espion = new Espion { Nom = nom, CodeNom = codeNom };
            _context.Espions.Add(espion);
            await _context.SaveChangesAsync();
        }

        public async Task AjouterMissionAEspionAsync(string codeNom, string ville, int annee)
        {
            var espion = await _context.Espions
                                       .FirstOrDefaultAsync(e => e.CodeNom == codeNom);
            if (espion == null)
            {
                throw new InvalidOperationException("Espion introuvable.");
            }

            var mission = new Mission { Ville = ville, Annee = annee };
            espion.Missions ??= new List<Mission>(); 
            espion.Missions.Add(mission);
            await _context.SaveChangesAsync();
        }

        public async Task<IAsyncEnumerable<Espion>> GetEspionsByVilleAsync(string ville)
        {
            var espions = _context.Missions
                                  .Where(m => m.Ville == ville)
                                  .SelectMany(m => m.Espions)
                                  .Distinct();

            return await Task.FromResult(espions.AsAsyncEnumerable());
        }
    }
}
