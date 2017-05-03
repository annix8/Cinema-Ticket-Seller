namespace CinemaTickets.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSeatsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        SeatID = c.Int(nullable: false, identity: true),
                        Row = c.Int(nullable: false),
                        Column = c.Int(nullable: false),
                        HallID = c.Int(nullable: false),
                        ProjectionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SeatID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Seats");
        }
    }
}
