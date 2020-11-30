namespace Web_Crawler_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fir : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlayersModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        G = c.String(),
                        PTS = c.String(),
                        TRB = c.String(),
                        AST = c.String(),
                        FG = c.String(),
                        FG3 = c.String(),
                        FT = c.String(),
                        eFG = c.String(),
                        PER = c.String(),
                        WS = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PlayersModels");
        }
    }
}
