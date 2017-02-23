namespace Beers.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertSpanishCities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.City",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Country_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.Country_Id)
                .Index(t => t.Country_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.City", "Country_Id", "dbo.Country");
            DropIndex("dbo.City", new[] { "Country_Id" });
            DropTable("dbo.City");
        }
    }
}
