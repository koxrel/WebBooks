namespace WebBooks.BookContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimeInOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Time", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Time");
        }
    }
}
