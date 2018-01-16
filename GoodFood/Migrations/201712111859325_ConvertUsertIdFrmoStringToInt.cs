namespace GoodFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConvertUsertIdFrmoStringToInt : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Favourites", new[] { "User_Id" });
            DropColumn("dbo.Favourites", "userId");
            RenameColumn(table: "dbo.Favourites", name: "User_Id", newName: "userId");
            AlterColumn("dbo.Favourites", "userId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Favourites", "userId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Favourites", new[] { "userId" });
            AlterColumn("dbo.Favourites", "userId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Favourites", name: "userId", newName: "User_Id");
            AddColumn("dbo.Favourites", "userId", c => c.Int(nullable: false));
            CreateIndex("dbo.Favourites", "User_Id");
        }
    }
}
