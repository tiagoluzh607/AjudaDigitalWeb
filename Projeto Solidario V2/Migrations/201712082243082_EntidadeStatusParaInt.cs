namespace Projeto_Solidario_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntidadeStatusParaInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Entidades", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Entidades", "Status", c => c.Boolean(nullable: false));
        }
    }
}
