namespace courierf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Booking", "Distance", c => c.Long());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Booking", "Distance");
        }
    }
}
