namespace Homework1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSurvey : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Surveys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        BookId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                        isBookAtLibrary = c.Boolean(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.GenreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Surveys", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Surveys", "BookId", "dbo.Books");
            DropIndex("dbo.Surveys", new[] { "GenreId" });
            DropIndex("dbo.Surveys", new[] { "BookId" });
            DropTable("dbo.Surveys");
        }
    }
}
