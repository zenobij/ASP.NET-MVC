using MyCinema.Data.Models;
using MyCinema.Data.Repository.RepoBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace MyCinema.Data.Repository
{
    public class RepoMovie : RepositoryBase<Movie>
    {
        /// <summary>
        /// Ne renvoie que les titres des films
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetTitles()
        {
            return Context.Movies.Select(f => f.Title).ToList();
        }

        public override void Delete(int id)
        {
            //Je récupère l'url du fichier sur le serveur
            //Le répertoire est différent actuellement car il n'est pas 
            //résolu => iis express

            string path = Path.GetFullPath(GetById(id).CoverURL.Substring(2));

            //Permet de savoir où je suis (autre moyen)
            string pathReel = HostingEnvironment.MapPath(GetById(id).CoverURL);

            if (File.Exists(path))
            {
                if (Path.GetFileName(path) != "movie.jpg")
                {
                    File.Delete(path);
                }
            }
            //Sert à déclencher la version de la méthode du parent
            base.Delete(id);
        }
    }
}
