namespace Praha20191113.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDirectorToMoviesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Director", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Director");
        }
    }
}
