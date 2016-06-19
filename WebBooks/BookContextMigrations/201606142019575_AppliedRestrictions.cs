namespace WebBooks.BookContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppliedRestrictions : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "LastName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Books", "Title", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Orders", "Credentials", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Credentials", c => c.String());
            AlterColumn("dbo.Genres", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Books", "Title", c => c.String(maxLength: 200));
            AlterColumn("dbo.Authors", "LastName", c => c.String(maxLength: 100));
        }
    }
}
