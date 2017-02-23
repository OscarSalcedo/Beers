namespace Beers.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Beer",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        BeerType_Id = c.Guid(),
                        Country_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BeerType", t => t.BeerType_Id)
                .ForeignKey("dbo.Country", t => t.Country_Id)
                .Index(t => t.BeerType_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.BeerType",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Beer", "Country_Id", "dbo.Country");
            DropForeignKey("dbo.Beer", "BeerType_Id", "dbo.BeerType");
            DropIndex("dbo.Beer", new[] { "Country_Id" });
            DropIndex("dbo.Beer", new[] { "BeerType_Id" });
            DropTable("dbo.Country");
            DropTable("dbo.BeerType");
            DropTable("dbo.Beer");
        }
    }
}
