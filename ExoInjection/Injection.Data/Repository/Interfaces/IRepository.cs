using Injection.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Injection.Data.Repository.Interfaces
{
    public interface IRepository
    {
        IEnumerable<Personne> GetAll();
    }
}
