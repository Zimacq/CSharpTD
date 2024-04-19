using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Thomas.RG.DAL.Models;

namespace Thomas.RG.DAL.Models
{
    public class Espion
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nom { get; set; }

        [Required]
        [MaxLength(50)]
        public string CodeNom { get; set; }

        public ICollection<Mission> Missions { get; set; } = new List<Mission>();
    }
}
