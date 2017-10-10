namespace WpfSampleProj.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeScripts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeHours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkDate = c.DateTime(nullable: false),
                        Description = c.String(maxLength: 80),
                        HoursWorked = c.Int(nullable: false),
                        EmployeeRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeRefId, cascadeDelete: true)
                .Index(t => t.EmployeeRefId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeNumber = c.Int(nullable: false, identity: true),
                        EmployeeLastName = c.String(),
                        EmployeeFirstName = c.String(),
                        HireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeNumber);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeHours", "EmployeeRefId", "dbo.Employees");
            DropIndex("dbo.EmployeeHours", new[] { "EmployeeRefId" });
            DropTable("dbo.Employees");
            DropTable("dbo.EmployeeHours");
        }
    }
}
