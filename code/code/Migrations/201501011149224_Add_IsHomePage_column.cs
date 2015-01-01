namespace code.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_IsHomePage_column : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "IsHomePage", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pages", "IsHomePage");
        }
    }
}
