namespace IdentitySample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class extra : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Suspendre", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Suspendre");
        }
    }
}
