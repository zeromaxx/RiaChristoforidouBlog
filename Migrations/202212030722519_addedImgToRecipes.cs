namespace RiaChristoforidouBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedImgToRecipes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "Thumbnail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "Thumbnail");
        }
    }
}
