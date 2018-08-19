using System;
using ExoMvcIdentity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExoMvcIdentity.Startup))]
namespace ExoMvcIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            // J'ai besoin d'une instance de DbContext pour écrire en DB
            ApplicationDbContext context = new ApplicationDbContext();

            // Pour créer un nouveau rôle j'ai besoin d'un manager
            // parce que c'est la logique que Microsoft à décier d'utiliser
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // J'ai aussi besoin d'un manager pour créer des users
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // Les managers et stores ne sont finalement que des repos génériques
            // et asynchrones qui vont faire pour moi les principales manipulations
            // des entités user et rôle

            // Si le role d'admin n'existe pas encore
            if(!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole // Vient du framework Identity
                {
                    Name = "Admin"
                };
                // Je me sers de mon manager pour insérer "dans les règles" le
                // rôle dans sa table rôle
                roleManager.Create(role);

                // Maintenant que le rôle existe, j'aimerais y associer un user
                // Malgré qu'ApplicationUser soit un IdentityUser, il faut l'écrire comment tel
                var user = new ApplicationUser(); // Déjà présent dans ItentityModels
                user.UserName = "Admin";
                user.Email = "Admin@root.com";
                // Le mot de passe est à part et sera inséré plus tard
                string usrPWD = "Mach1!!!"; // "Mach1!!!" est un mdp idéal (8 caractères, MAJ, min, chiffre, caractères spéciaux)
                // Je vérifie que le user est bien créé
                var chkUser = userManager.Create(user, usrPWD);
                // Si oui
                if (chkUser.Succeeded)
                {
                    // Je peux lui associer le role "Admin"
                    userManager.AddToRole(user.Id, "Admin");
                }
            }
            // Pour créer un rôle simplement sans utilisateur associé
            if (!roleManager.RoleExists("Basic"))
            {
                var role = new IdentityRole
                {
                    Name = "Basic"
                };
                roleManager.Create(role);
            }
        }
    }
}
