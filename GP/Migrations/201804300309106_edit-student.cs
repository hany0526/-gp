namespace GP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editstudent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "file", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "file", c => c.Binary());
        }
    }
}
