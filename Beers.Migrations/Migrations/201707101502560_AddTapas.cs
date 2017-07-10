namespace Beers.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTapas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tapas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tapas");
        }
    }
}
