using Injection.Data.Models;
using Injection.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Injection.Data.Repository
{
    public class RepoFake : IRepository
    {
        public IEnumerable<Personne> GetAll()
        {
            return new List<Personne>
            {
                new Personne{PersonneId = 1,Nom = "Leroi", Prenom = "Marcel", Email="", GenreId = 1},
                new Personne{PersonneId = 2,Nom = "Leroi", Prenom = "Marie", Email="", GenreId = 2},
                new Personne{PersonneId = 3,Nom = "Leroi", Prenom = "Ludovic", Email="", GenreId = 1}
            };
        }
    }
}
