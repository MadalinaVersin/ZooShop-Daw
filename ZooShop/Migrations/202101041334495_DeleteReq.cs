namespace ZooShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteReq : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Breeds", "BreedName", c => c.String(maxLength: 30));
            AlterColumn("dbo.Vaccines", "Name", c => c.String(maxLength: 30));
            AlterColumn("dbo.ContactInfoes", "Email", c => c.String());
            AlterColumn("dbo.ContactInfoes", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Distributors", "DistributorName", c => c.String(maxLength: 200));
            AlterColumn("dbo.Products", "Name", c => c.String(maxLength: 200));
            AlterColumn("dbo.Products", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ImagePath", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Distributors", "DistributorName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.ContactInfoes", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.ContactInfoes", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Vaccines", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Breeds", "BreedName", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
