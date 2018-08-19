using ExoRevision.Data.Repository;
using ExoRevision.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            RepoFruit repo = new RepoFruit();

            foreach (var item in repo.GetAll())
            {
                System.Console.WriteLine(item.Nom);
            }

            //Création d'un fruit

            FruitDTO fd = new FruitDTO
            {
                Nom = "abricot",
                Couleur = "abricot"
            };

            System.Console.WriteLine(repo.Add(fd));

            foreach (var item in repo.GetAll())
            {
                System.Console.WriteLine(item.Nom);
            }

            System.Console.ReadLine();
        }
    }
}
