using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Thomas.RG.DAL; 
using Thomas.RG.DAL.Services;

public class Program
{
    public static async Task Main(string[] args)
    {

        var serviceProvider = new ServiceCollection()
            .AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql("server=localhost;port=3306;database=dbcontext3;user=root;password=;", 
                new MySqlServerVersion(new Version(8, 0, 21)))) 
            .BuildServiceProvider();


        var espionService = serviceProvider.GetRequiredService<IEspionService>();


        if (args.Length > 0 && args[0].ToLower() == "-import" && args.Length > 1)
        {
            string filePath = args[1];
            if (File.Exists(filePath))
            {
                string[] lines = await File.ReadAllLinesAsync(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(';').Select(p => p.Trim()).ToArray();
                    if (parts.Length == 2)
                    {
                        await espionService.AjouterEspionAsync(parts[0], parts[1]);
                    }
                }
                Console.WriteLine("Importation des espions terminée.");
            }
            else
            {
                Console.WriteLine($"Le fichier spécifié n'a pas été trouvé : {filePath}");
            }
        }

    }
}
