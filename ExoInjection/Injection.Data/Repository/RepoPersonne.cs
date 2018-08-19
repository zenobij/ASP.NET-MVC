using Injection.Data.Models;
using Injection.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Injection.Data.Repository
{
    public class RepoPersonne : IRepository
    {
        PersonneContext context;
        public RepoPersonne()
        {
            context = new PersonneContext();
        }
        public IEnumerable<Personne> GetAll()
        {
            return context.Personne;
        }
    }
}
