using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace ExoIdentityExtend.Models.Extensions
{
    //Je crée une méthode d'extension pour IIdentity afin d'augmenter ses fonctionnalités et permettre ainsi d'utiliser facilement les champs que j'ai créé en cookie sans devoir appeler le DBcontext et donc faire un appel DB
    public static class IdentityExtensions
    {
        //C'est IIdentity que je dois étendre car c'est lui qui a les définitions des méthodes. C'est le sommet de la pyramide
        public static string GetDateOfBith(this IIdentity identity)
        {
            //Recherche dans les clés-valeurs après celle qui me convient
            var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.DateOfBirth);
            //Si la clé-valeur existe alors je prends la valeur
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}