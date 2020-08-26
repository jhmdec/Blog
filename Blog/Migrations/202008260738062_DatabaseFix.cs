namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Blogs", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Blogs", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            AddColumn("dbo.Blogs", "Author_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Posts", "CommentsAllowed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Comments", "Author_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.AspNetUsers", "UserImg", c => c.String());
            AlterColumn("dbo.Blogs", "Body", c => c.String(nullable: false, maxLength: 512));
            AlterColumn("dbo.Blogs", "UserId", c => c.String());
            AlterColumn("dbo.Comments", "Body", c => c.String(nullable: false, maxLength: 512));
            AlterColumn("dbo.Comments", "UserId", c => c.String());
            CreateIndex("dbo.Blogs", "Author_Id");
            CreateIndex("dbo.Comments", "Author_Id");
            AddForeignKey("dbo.Comments", "Author_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Blogs", "Author_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "Author_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "Author_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "Author_Id" });
            DropIndex("dbo.Blogs", new[] { "Author_Id" });
            AlterColumn("dbo.Comments", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Comments", "Body", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Blogs", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Blogs", "Body", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.AspNetUsers", "UserImg");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.Comments", "Author_Id");
            DropColumn("dbo.Posts", "CommentsAllowed");
            DropColumn("dbo.Blogs", "Author_Id");
            CreateIndex("dbo.Comments", "UserId");
            CreateIndex("dbo.Blogs", "UserId");
            AddForeignKey("dbo.Blogs", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
