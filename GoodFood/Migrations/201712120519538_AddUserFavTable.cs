namespace GoodFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserFavTable : DbMigration
    {
        public override void Up()
        {
       
            CreateTable(
                "dbo.UserFavs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        RecipeId = c.Int(nullable: false),
                        userId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.userId)
                .Index(t => t.RecipeId)
                .Index(t => t.userId);
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Favourites",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        recepId = c.Int(nullable: false),
                        userId = c.String(maxLength: 128),
                        Recipe_id = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            DropForeignKey("dbo.UserFavs", "userId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserFavs", "RecipeId", "dbo.Recipes");
            DropIndex("dbo.UserFavs", new[] { "userId" });
            DropIndex("dbo.UserFavs", new[] { "RecipeId" });
            DropTable("dbo.UserFavs");
            
        }
    }
}
