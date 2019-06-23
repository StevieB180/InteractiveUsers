namespace Shapeclasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Card",
                c => new
                    {
                        CardID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Text = c.String(),
                        Top = c.Double(nullable: false),
                        Left = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CardID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Card");
        }
    }
}
