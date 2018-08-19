namespace TestSignalR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chat",
                c => new
                    {
                        ChatId = c.Int(nullable: false, identity: true),
                        Pseudo = c.String(nullable: false, maxLength: 50),
                        Message = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        IP = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ChatId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Chat");
        }
    }
}
