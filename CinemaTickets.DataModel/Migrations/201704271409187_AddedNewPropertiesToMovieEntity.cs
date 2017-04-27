namespace CinemaTickets.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewPropertiesToMovieEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Rating", c => c.String());
            AddColumn("dbo.Movies", "Language", c => c.String());
            AddColumn("dbo.Movies", "Minutes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Minutes");
            DropColumn("dbo.Movies", "Language");
            DropColumn("dbo.Movies", "Rating");
        }
    }
}
