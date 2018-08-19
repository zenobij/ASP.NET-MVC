using ExoRevision.Data.Models;
using ExoRevision.Data.Models.Converters;
using ExoRevision.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoRevision.Data.Repository
{
    public class RepoFruit
    {
        private ExoRevisionContext Context { get; set; }

        public RepoFruit()
        {
            Context = new ExoRevisionContext();
        }

        public IEnumerable<FruitDTO> GetAll()
        {
            return Context.Fruit.ToDTO();
        }

        public bool Add(FruitDTO fd)
        {
            try
            {
                Context.Fruit.Add(fd.ToData());
                Context.SaveChanges();
                return true;
            }
            catch { }
            return false;
        }
    }
}
