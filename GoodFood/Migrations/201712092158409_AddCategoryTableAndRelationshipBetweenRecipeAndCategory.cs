namespace GoodFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryTableAndRelationshipBetweenRecipeAndCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Recipes", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Recipes", "CategoryId");
            AddForeignKey("dbo.Recipes", "CategoryId", "dbo.Categories", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Recipes", new[] { "CategoryId" });
            DropColumn("dbo.Recipes", "CategoryId");
            DropTable("dbo.Categories");
        }
    }
}
