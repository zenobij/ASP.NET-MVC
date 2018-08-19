using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoRevision.DTO.Models
{
    public class FruitDTO
    {
        public int FruitId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nom { get; set; }

        [StringLength(50)]
        public string Couleur { get; set; }
    }
}
