namespace RiaChristoforidouBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredrecipe : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recipes", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Recipes", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Recipes", "Description", c => c.String());
            AlterColumn("dbo.Recipes", "Title", c => c.String());
        }
    }
}
