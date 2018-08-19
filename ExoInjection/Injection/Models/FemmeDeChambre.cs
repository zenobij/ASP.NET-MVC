using Injection.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Injection.Models
{
    class FemmeDeChambre
    {
        //Quand une classe A à besoin d'une classe B pour fonctionner
        //La classe B est appelée dépendance de A et leur relation est 
        //appellée couplage.
        //Il y a plusieurs niveaux de couplage du plus faible ou plus fort. Celui-ci est le plus fort.

        //AspiAEG aspi = new AspiAEG();

        //Le couplage qui suit est dit intermédiaire car il y a un mieux
        //je ne m'occupe plus de l'instanciation de ma classe dépendante
        //je la reçois par constructeur

        //AspiAEG aspi;

        //public FemmeDeChambre(AspiAEG a)
        //{
        //    aspi = a;
        //}


        //Dans cet exemple on parle d'injection de dépendance car la classe a reçu la dépendance dont elle a besoin pour fonctionner
        //de l'extérieur
        //Ce principe fait partie d'un ensemble plus vaste de procédés appelés IOC (en français : inversion de contrôle)
        IAspirateur aspi;

        public FemmeDeChambre(IAspirateur a)
        {
            aspi = a;
        }

        public void PasserAspirateur()
        {
            aspi.Aspirer();
        }
    }
}
