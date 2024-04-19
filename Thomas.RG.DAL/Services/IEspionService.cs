using System.Collections.Generic;
using System.Threading.Tasks;
using Thomas.RG.DAL.Models;

namespace Thomas.RG.DAL.Services
{
    public interface IEspionService
    {
        Task AjouterEspionAsync(string nom, string codeNom);
        Task AjouterMissionAEspionAsync(string codeNom, string ville, int annee);
        Task<IAsyncEnumerable<Espion>> GetEspionsByVilleAsync(string ville);
    }
}
