using ExoRevision.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoRevision.Data.Models.Converters
{
    public static class ToFruitDTO
    {
        public static FruitDTO ToDTO (this Fruit f)
        {
            return new FruitDTO
            {
                FruitId = f.FruitId,
                Nom = f.Nom,
                Couleur = f.Couleur
            };
        }

        public static IEnumerable<FruitDTO> ToDTO (this IEnumerable<Fruit> liste)
        {
            return liste.Select(f => f.ToDTO());
        }
    }
}
