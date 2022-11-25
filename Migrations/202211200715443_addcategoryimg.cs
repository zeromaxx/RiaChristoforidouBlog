namespace RiaChristoforidouBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcategoryimg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Thumbnail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Thumbnail");
        }
    }
}
