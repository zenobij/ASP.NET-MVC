namespace ExoRevision.Data.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ExoRevisionContext : DbContext
    {
        public ExoRevisionContext()
            : base("name=ExoRevisionConString")
        {
        }

        public virtual DbSet<Fruit> Fruit { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
