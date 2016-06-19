namespace WebBooks.BookContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationshipFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Books", new[] { "Order_Id" });
            CreateTable(
                "dbo.OrderBooks",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Book_Id })
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Book_Id);
            
            DropColumn("dbo.Books", "Order_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Order_Id", c => c.Int());
            DropForeignKey("dbo.OrderBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.OrderBooks", "Order_Id", "dbo.Orders");
            DropIndex("dbo.OrderBooks", new[] { "Book_Id" });
            DropIndex("dbo.OrderBooks", new[] { "Order_Id" });
            DropTable("dbo.OrderBooks");
            CreateIndex("dbo.Books", "Order_Id");
            AddForeignKey("dbo.Books", "Order_Id", "dbo.Orders", "Id");
        }
    }
}
