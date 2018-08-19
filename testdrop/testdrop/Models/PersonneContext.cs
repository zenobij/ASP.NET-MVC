namespace testdrop.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PersonneContext : DbContext
    {
        public PersonneContext()
            : base("name=PersonneContext")
        {
        }

        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Personne> Personne { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .HasMany(e => e.Personne)
                .WithRequired(e => e.Genre)
                .WillCascadeOnDelete(false);
        }
    }
}
