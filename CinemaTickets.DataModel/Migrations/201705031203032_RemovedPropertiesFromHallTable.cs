namespace CinemaTickets.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedPropertiesFromHallTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Halls", "RowNumber");
            DropColumn("dbo.Halls", "SeatNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Halls", "SeatNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Halls", "RowNumber", c => c.Int(nullable: false));
        }
    }
}
