namespace ZooShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReqContact : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ContactInfoes", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.ContactInfoes", "PhoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ContactInfoes", "PhoneNumber", c => c.String());
            AlterColumn("dbo.ContactInfoes", "Email", c => c.String());
        }
    }
}
