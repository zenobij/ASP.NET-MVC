namespace MyCinema.Data.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MyCinemaContext : DbContext
    {
        public MyCinemaContext()
            : base("name=MyCinemaContext")
        {
        }

        public virtual DbSet<Movie> Movies { get; set; }
    }


    /*
     * 
     * Pour Cr�er la DB depuis un Projet Data :
     *  * Enable-Migrations -ProjectName MyCinema.Data
     *  * Add-Migration -ProjectName MyCinema.Data -Name CreateDB
     *  * Update-Database -Verbose -ProjectName MyCinema.Data 
     *  
     *  NB : Enable-Migrations ne s'utilise qu'une seule fois
     *       A chaque mofification de la DB : 
     *          * Cr�er une nouvelle classe ou modifier la ou les classes
     *          * Add-Migration pour cr�er un nouveau fichier migration
     *          * Update-Database pour appliquer les modifications
     * 
     * https://coding.abel.nu/2012/03/ef-migrations-command-reference/#Update-Database
     * 
     */
}