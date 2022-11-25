namespace RiaChristoforidouBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Recipes", "Thumbnail");
            DropColumn("dbo.Recipes", "SingleIngredient");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "SingleIngredient", c => c.String());
            AddColumn("dbo.Recipes", "Thumbnail", c => c.String());
        }
    }
}
