using Injection.Models;
using Injection.Models.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Injection
{
    class Program
    {
        static void Main(string[] args)
        {
            //AspiAEG nouvelAspi = new AspiAEG();

            //AspiRoover nouvelAspi = new AspiRoover();

            //FemmeDeChambre Conchita = new FemmeDeChambre(nouvelAspi);

            //Conchita.PasserAspirateur();


            using (var container = new StandardKernel())
            {
                if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
                {
                    //J'enregistre l'association "interface"->"instance"
                    container.Bind<IAspirateur>().To<AspiRoover>();
                }
                else
                {
                    //J'enregistre une autre association mais dans un contexte
                    //différent
                    container.Bind<IAspirateur>().To<AspiAEG>();
                }

                //Je me sers de ninject pour instancier correctement
                //la femme de chambre avec la bonne implémentation d'IAspirateur
                var Conchita = container.Get<FemmeDeChambre>();

                Conchita.PasserAspirateur();
            }


            

            

            Console.ReadLine();
        }
    }
}
