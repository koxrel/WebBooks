namespace WebBooks.BookContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedMaxLengthISBN : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Isbn", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Isbn", c => c.String(maxLength: 13));
        }
    }
}
