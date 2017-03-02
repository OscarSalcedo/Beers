namespace Beers.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCityToBeer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Beer", "Graduation", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Beer", "City_Id", c => c.Guid());
            CreateIndex("dbo.Beer", "City_Id");
            AddForeignKey("dbo.Beer", "City_Id", "dbo.City", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Beer", "City_Id", "dbo.City");
            DropIndex("dbo.Beer", new[] { "City_Id" });
            DropColumn("dbo.Beer", "City_Id");
            DropColumn("dbo.Beer", "Graduation");
        }
    }
}
