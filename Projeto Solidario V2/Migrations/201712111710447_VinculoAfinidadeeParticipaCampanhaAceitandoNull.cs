namespace Projeto_Solidario_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VinculoAfinidadeeParticipaCampanhaAceitandoNull : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VinculoAfinidades", "Campanhaid", "dbo.Campanhas");
            DropForeignKey("dbo.VinculoAfinidades", "Entidadeid", "dbo.Entidades");
            DropForeignKey("dbo.VinculoAfinidades", "Voluntarioid", "dbo.Voluntarios");
            DropForeignKey("dbo.ParticipaCampanhas", "Entidadeid", "dbo.Entidades");
            DropForeignKey("dbo.ParticipaCampanhas", "Voluntarioid", "dbo.Voluntarios");
            DropIndex("dbo.VinculoAfinidades", new[] { "Voluntarioid" });
            DropIndex("dbo.VinculoAfinidades", new[] { "Entidadeid" });
            DropIndex("dbo.VinculoAfinidades", new[] { "Campanhaid" });
            DropIndex("dbo.ParticipaCampanhas", new[] { "Voluntarioid" });
            DropIndex("dbo.ParticipaCampanhas", new[] { "Entidadeid" });
            AlterColumn("dbo.VinculoAfinidades", "Voluntarioid", c => c.Int());
            AlterColumn("dbo.VinculoAfinidades", "Entidadeid", c => c.Int());
            AlterColumn("dbo.VinculoAfinidades", "Campanhaid", c => c.Int());
            AlterColumn("dbo.ParticipaCampanhas", "Voluntarioid", c => c.Int());
            AlterColumn("dbo.ParticipaCampanhas", "Entidadeid", c => c.Int());
            CreateIndex("dbo.VinculoAfinidades", "Voluntarioid");
            CreateIndex("dbo.VinculoAfinidades", "Entidadeid");
            CreateIndex("dbo.VinculoAfinidades", "Campanhaid");
            CreateIndex("dbo.ParticipaCampanhas", "Voluntarioid");
            CreateIndex("dbo.ParticipaCampanhas", "Entidadeid");
            AddForeignKey("dbo.VinculoAfinidades", "Campanhaid", "dbo.Campanhas", "id");
            AddForeignKey("dbo.VinculoAfinidades", "Entidadeid", "dbo.Entidades", "id");
            AddForeignKey("dbo.VinculoAfinidades", "Voluntarioid", "dbo.Voluntarios", "id");
            AddForeignKey("dbo.ParticipaCampanhas", "Entidadeid", "dbo.Entidades", "id");
            AddForeignKey("dbo.ParticipaCampanhas", "Voluntarioid", "dbo.Voluntarios", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParticipaCampanhas", "Voluntarioid", "dbo.Voluntarios");
            DropForeignKey("dbo.ParticipaCampanhas", "Entidadeid", "dbo.Entidades");
            DropForeignKey("dbo.VinculoAfinidades", "Voluntarioid", "dbo.Voluntarios");
            DropForeignKey("dbo.VinculoAfinidades", "Entidadeid", "dbo.Entidades");
            DropForeignKey("dbo.VinculoAfinidades", "Campanhaid", "dbo.Campanhas");
            DropIndex("dbo.ParticipaCampanhas", new[] { "Entidadeid" });
            DropIndex("dbo.ParticipaCampanhas", new[] { "Voluntarioid" });
            DropIndex("dbo.VinculoAfinidades", new[] { "Campanhaid" });
            DropIndex("dbo.VinculoAfinidades", new[] { "Entidadeid" });
            DropIndex("dbo.VinculoAfinidades", new[] { "Voluntarioid" });
            AlterColumn("dbo.ParticipaCampanhas", "Entidadeid", c => c.Int(nullable: false));
            AlterColumn("dbo.ParticipaCampanhas", "Voluntarioid", c => c.Int(nullable: false));
            AlterColumn("dbo.VinculoAfinidades", "Campanhaid", c => c.Int(nullable: false));
            AlterColumn("dbo.VinculoAfinidades", "Entidadeid", c => c.Int(nullable: false));
            AlterColumn("dbo.VinculoAfinidades", "Voluntarioid", c => c.Int(nullable: false));
            CreateIndex("dbo.ParticipaCampanhas", "Entidadeid");
            CreateIndex("dbo.ParticipaCampanhas", "Voluntarioid");
            CreateIndex("dbo.VinculoAfinidades", "Campanhaid");
            CreateIndex("dbo.VinculoAfinidades", "Entidadeid");
            CreateIndex("dbo.VinculoAfinidades", "Voluntarioid");
            AddForeignKey("dbo.ParticipaCampanhas", "Voluntarioid", "dbo.Voluntarios", "id", cascadeDelete: true);
            AddForeignKey("dbo.ParticipaCampanhas", "Entidadeid", "dbo.Entidades", "id", cascadeDelete: true);
            AddForeignKey("dbo.VinculoAfinidades", "Voluntarioid", "dbo.Voluntarios", "id", cascadeDelete: true);
            AddForeignKey("dbo.VinculoAfinidades", "Entidadeid", "dbo.Entidades", "id", cascadeDelete: true);
            AddForeignKey("dbo.VinculoAfinidades", "Campanhaid", "dbo.Campanhas", "id", cascadeDelete: true);
        }
    }
}
