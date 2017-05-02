namespace CinemaTickets.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageTableAndImageIDPropertyToMovieTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        ImageData = c.Binary(),
                    })
                .PrimaryKey(t => t.ImageID);
            
            AddColumn("dbo.Movies", "ImageID", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "ImageID");
            AddForeignKey("dbo.Movies", "ImageID", "dbo.Images", "ImageID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "ImageID", "dbo.Images");
            DropIndex("dbo.Movies", new[] { "ImageID" });
            DropColumn("dbo.Movies", "ImageID");
            DropTable("dbo.Images");
        }
    }
}
