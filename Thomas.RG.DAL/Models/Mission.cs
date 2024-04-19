using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Thomas.RG.DAL.Models
{
    public class Mission
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]  
        public string Ville { get; set; }

        [Required]
        public int Annee { get; set; }

        public virtual ICollection<Espion> Espions { get; set; } = new List<Espion>();
    }
}
