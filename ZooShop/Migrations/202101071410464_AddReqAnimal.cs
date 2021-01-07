namespace ZooShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReqAnimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Animals", "Name", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Animals", "Gender", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Animals", "Gender", c => c.String());
            AlterColumn("dbo.Animals", "Name", c => c.String(maxLength: 200));
        }
    }
}
