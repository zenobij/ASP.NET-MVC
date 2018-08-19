using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ExoIdentityExtend.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //Les propriétés que je décris ici seront, après migration, des colonnes en plus dans la table d'autentification AspNetUser
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            //Les claims sont des clés-valeurs qui vont être stockés dans un cookie
            //L'id et le username sont déjà là par défaut mais je souhaite rajouter
            //la date de naissance pour une utilisation simplifiée
            //On peut définir une clé à la main ou utiliser une clé prédéfinie

            userIdentity.AddClaim(new Claim(ClaimTypes.DateOfBirth, this.DateOfBirth.ToString()));

            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}