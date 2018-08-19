namespace MyCinema.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Director = c.String(nullable: false, maxLength: 100),
                        ReleaseDate = c.DateTime(),
                        Resume = c.String(),
                        CoverURL = c.String(maxLength: 150,defaultValue:"~/Resources/movie.jpg"),
                    })
                .PrimaryKey(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movie");
        }
    }
}
