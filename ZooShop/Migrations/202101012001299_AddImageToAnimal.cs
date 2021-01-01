namespace ZooShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageToAnimal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Animals", "ImagePath");
        }
    }
}
