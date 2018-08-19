namespace MyCinema.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNotNullCoverURL : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movie", "CoverURL", c => c.String(nullable: false, maxLength: 150,defaultValue:"~/Resources/movie.jpg"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movie", "CoverURL", c => c.String(maxLength: 150));
        }
    }
}
