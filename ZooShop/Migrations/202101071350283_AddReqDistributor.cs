namespace ZooShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReqDistributor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Distributors", "DistributorName", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Distributors", "DistributorName", c => c.String(maxLength: 200));
        }
    }
}
