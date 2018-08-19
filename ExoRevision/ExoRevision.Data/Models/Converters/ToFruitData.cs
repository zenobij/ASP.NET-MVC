using ExoRevision.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoRevision.Data.Models.Converters
{
    public static class ToFruitData
    {
        public static Fruit ToData(this FruitDTO f)
        {
            return new Fruit
            {
                FruitId = f.FruitId,
                Nom = f.Nom,
                Couleur = f.Couleur
            };
        }

        public static IEnumerable<Fruit> ToData(this IEnumerable<FruitDTO> liste)
        {
            return liste.Select(f => f.ToData());
        }
    }
}
