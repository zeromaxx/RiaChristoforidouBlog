namespace RiaChristoforidouBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String());
        }
    }
}
