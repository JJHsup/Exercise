namespace Response_Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Build_Tester : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TesterInfomationModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TesterName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TesterInfomationModels");
        }
    }
}
