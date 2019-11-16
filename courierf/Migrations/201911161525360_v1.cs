namespace courierf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courier", "Courier_id", "dbo.Booking");
            DropIndex("dbo.Courier", new[] { "Courier_id" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Courier", "Courier_id");
            AddForeignKey("dbo.Courier", "Courier_id", "dbo.Booking", "Booking_id");
        }
    }
}
