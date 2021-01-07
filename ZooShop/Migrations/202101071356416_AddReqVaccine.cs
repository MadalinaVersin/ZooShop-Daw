namespace ZooShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReqVaccine : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vaccines", "Name", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vaccines", "Name", c => c.String(maxLength: 30));
        }
    }
}
