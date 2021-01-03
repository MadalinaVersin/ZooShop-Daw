namespace ZooShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductDistributorContactInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactInfoes",
                c => new
                    {
                        ContactInfoId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.ContactInfoId);
            
            CreateTable(
                "dbo.Distributors",
                c => new
                    {
                        DistributorId = c.Int(nullable: false),
                        DistributorName = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.DistributorId)
                .ForeignKey("dbo.ContactInfoes", t => t.DistributorId)
                .Index(t => t.DistributorId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Details = c.String(),
                        Price = c.Int(nullable: false),
                        ImagePath = c.String(),
                        DistributorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Distributors", t => t.DistributorId, cascadeDelete: true)
                .Index(t => t.DistributorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "DistributorId", "dbo.Distributors");
            DropForeignKey("dbo.Distributors", "DistributorId", "dbo.ContactInfoes");
            DropIndex("dbo.Products", new[] { "DistributorId" });
            DropIndex("dbo.Distributors", new[] { "DistributorId" });
            DropTable("dbo.Products");
            DropTable("dbo.Distributors");
            DropTable("dbo.ContactInfoes");
        }
    }
}
