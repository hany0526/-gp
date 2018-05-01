namespace GP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Departmentid", c => c.Int(nullable: true));
            AddColumn("dbo.Students", "phone", c => c.Int(nullable: true));
            AddColumn("dbo.Students", "leaderid", c => c.Int(nullable: true));
            AddColumn("dbo.Students", "file", c => c.Binary());
            AddColumn("dbo.Professors", "Phone", c => c.Int(nullable: true));
            AddColumn("dbo.Professors", "Departmentid", c => c.Int(nullable: true));
            CreateIndex("dbo.Students", "Departmentid");
            CreateIndex("dbo.Students", "leaderid");
            CreateIndex("dbo.Professors", "Departmentid");
            AddForeignKey("dbo.Students", "Departmentid", "dbo.Departments", "id", cascadeDelete: false);
            AddForeignKey("dbo.Students", "leaderid", "dbo.Students", "id");
            AddForeignKey("dbo.Professors", "Departmentid", "dbo.Departments", "id", cascadeDelete: false);
            DropColumn("dbo.Students", "leader_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "leader_id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Professors", "Departmentid", "dbo.Departments");
            DropForeignKey("dbo.Students", "leaderid", "dbo.Students");
            DropForeignKey("dbo.Students", "Departmentid", "dbo.Departments");
            DropIndex("dbo.Professors", new[] { "Departmentid" });
            DropIndex("dbo.Students", new[] { "leaderid" });
            DropIndex("dbo.Students", new[] { "Departmentid" });
            DropColumn("dbo.Professors", "Departmentid");
            DropColumn("dbo.Professors", "Phone");
            DropColumn("dbo.Students", "file");
            DropColumn("dbo.Students", "leaderid");
            DropColumn("dbo.Students", "phone");
            DropColumn("dbo.Students", "Departmentid");
        }
    }
}
