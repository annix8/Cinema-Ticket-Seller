namespace CinemaTickets.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHallNumberAndEmployeeEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Email", c => c.String());
            AddColumn("dbo.Halls", "HallNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "MiddleName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "MiddleName", c => c.String());
            DropColumn("dbo.Halls", "HallNumber");
            DropColumn("dbo.Employees", "Email");
        }
    }
}
