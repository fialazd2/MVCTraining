namespace Praha20191113.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLanguagesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "LanguageID", c => c.Int());
            CreateIndex("dbo.Movies", "LanguageID");
            AddForeignKey("dbo.Movies", "LanguageID", "dbo.Languages", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "LanguageID", "dbo.Languages");
            DropIndex("dbo.Movies", new[] { "LanguageID" });
            DropColumn("dbo.Movies", "LanguageID");
            DropTable("dbo.Languages");
        }
    }
}
