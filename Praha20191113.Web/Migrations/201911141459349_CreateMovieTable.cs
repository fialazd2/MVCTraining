namespace Praha20191113.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMovieTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Genre = c.Int(nullable: false),
                        ReleasedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
