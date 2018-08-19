namespace testdrop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Personne")]
    public partial class Personne
    {
        public int PersonneId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nom { get; set; }

        [StringLength(50)]
        public string Prenom { get; set; }

        public int GenreId { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
