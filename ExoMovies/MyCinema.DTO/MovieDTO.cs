using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCinema.DTO
{
    /*
     * 
     * La couche DTO (data transfert object) est une couche contenant uniquement
     * Des classes utiles pour toutes les autres couches.
     * Ces classes DTO ne peuvent conetenir de méthodes de persistance ni d'ailleurs si possible de méthodes du tout.
     * DTO est donc un conteneur pour véhiculer des données.
     */
    public class MovieDTO
    {
        [Display(Name = "ID")]
        public int MovieId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Titre")]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Réalisateur")]
        public string Director { get; set; }

        [Display(Name ="Date de sortie")]
        //[DataType(DataType.Date)] Déclenche un datepicker mais celui du navigateur pas le nôtre => méfiance, le client verra-t'il la même chose que moi
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Résumé")]
        public string Resume { get; set; }

        [Display(Name = "Jaquette")]
        [StringLength(150)]
        public string CoverURL { get; set; }
    }
}
