namespace WebBooks.BookContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FullTitleProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "FullTitle", c => c.String());
            Sql("CREATE PROCEDURE ProcedureFullTitle AS BEGIN SET NOCOUNT ON;	update books set FullTitle = LOWER(replace(ISNULL(a.FirstName, '') + ' ' + ISNULL(a.MiddleName, '') + ' ' + a.LastName + ' ' + b.Title, '  ', ' ')) from (select ba.Author_Id, Book_Id from Books i join BookAuthors ba on i.Id = ba.Book_Id) auth join Authors a on auth.Author_Id = a.Id join Books b on b.Id = auth.Book_Id END");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "FullTitle");
            Sql("DROP PROCEDURE ProcedureFullTitle");
        }
    }
}
