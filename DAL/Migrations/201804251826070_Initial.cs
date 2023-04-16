namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tblStudentTestResult", "Duration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblStudentTestResult", "Duration", c => c.Long(nullable: false));
        }
    }
}
