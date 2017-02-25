namespace CinemaTickets.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Halls",
                c => new
                    {
                        HallID = c.Int(nullable: false, identity: true),
                        RowNumber = c.Int(nullable: false),
                        SeatNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HallID);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.MovieID);
            
            CreateTable(
                "dbo.Projections",
                c => new
                    {
                        ProjectionID = c.Int(nullable: false, identity: true),
                        HallID = c.Int(nullable: false),
                        MovieID = c.Int(nullable: false),
                        TimeOfProjection = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectionID)
                .ForeignKey("dbo.Halls", t => t.HallID, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieID, cascadeDelete: true)
                .Index(t => t.HallID)
                .Index(t => t.MovieID);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        ProjectionID = c.Int(nullable: false),
                        SeatNumber = c.Int(nullable: false),
                        RowNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TicketID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.Projections", t => t.ProjectionID, cascadeDelete: true)
                .Index(t => t.EmployeeID)
                .Index(t => t.ProjectionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "ProjectionID", "dbo.Projections");
            DropForeignKey("dbo.Tickets", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Projections", "MovieID", "dbo.Movies");
            DropForeignKey("dbo.Projections", "HallID", "dbo.Halls");
            DropIndex("dbo.Tickets", new[] { "ProjectionID" });
            DropIndex("dbo.Tickets", new[] { "EmployeeID" });
            DropIndex("dbo.Projections", new[] { "MovieID" });
            DropIndex("dbo.Projections", new[] { "HallID" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Projections");
            DropTable("dbo.Movies");
            DropTable("dbo.Halls");
            DropTable("dbo.Employees");
        }
    }
}
