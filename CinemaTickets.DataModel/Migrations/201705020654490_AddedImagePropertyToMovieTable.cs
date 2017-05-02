namespace CinemaTickets.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImagePropertyToMovieTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "MovieImage", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "MovieImage");
        }
    }
}
