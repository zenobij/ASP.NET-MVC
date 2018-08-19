using Injection.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Injection.Models
{
    class AspiRoover : IAspirateur
    {
        public void Aspirer()
        {
            Console.WriteLine("VROUUUUUUUUM  Roover");
        }
    }
}
