namespace CinemaTickets.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMiddleNameToEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "MiddleName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "MiddleName");
        }
    }
}
