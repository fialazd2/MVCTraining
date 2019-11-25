namespace Praha20191113.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeTypeChannge : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "ReleasedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime());
            AlterColumn("dbo.Movies", "ReleasedDate", c => c.DateTime());
        }
    }
}
