namespace Projeto_Solidario_V2.Migrations
{
    using Models;
    using Models.dao;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    public partial class CriaBancoV2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Afinidades",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.VinculoAfinidades",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Afinidadeid = c.Int(nullable: false),
                        Voluntarioid = c.Int(nullable: false),
                        Entidadeid = c.Int(nullable: false),
                        Campanhaid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Afinidades", t => t.Afinidadeid, cascadeDelete: true)
                .ForeignKey("dbo.Voluntarios", t => t.Voluntarioid, cascadeDelete: false)
                .ForeignKey("dbo.Entidades", t => t.Entidadeid, cascadeDelete: true)
                .ForeignKey("dbo.Campanhas", t => t.Campanhaid, cascadeDelete: false)
                .Index(t => t.Afinidadeid)
                .Index(t => t.Voluntarioid)
                .Index(t => t.Entidadeid)
                .Index(t => t.Campanhaid);
            
            CreateTable(
                "dbo.Campanhas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        DataInicial = c.DateTime(nullable: false),
                        DataFinal = c.DateTime(nullable: false),
                        Entidadeid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Entidades", t => t.Entidadeid, cascadeDelete: true)
                .Index(t => t.Entidadeid);
            
            CreateTable(
                "dbo.Entidades",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Loginid = c.Int(nullable: false),
                        Cidadeid = c.Int(nullable: false),
                        Nome = c.String(),
                        CnpjCpf = c.String(),
                        Logradouro = c.String(),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(),
                        Bairro = c.String(),
                        TipoEntidade = c.String(),
                        Estado = c.String(),
                        Cep = c.String(),
                        Telefone = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Cidades", t => t.Cidadeid, cascadeDelete: true)
                .ForeignKey("dbo.Logins", t => t.Loginid, cascadeDelete: true)
                .Index(t => t.Loginid)
                .Index(t => t.Cidadeid);
            
            CreateTable(
                "dbo.Cidades",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Governoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Loginid = c.Int(nullable: false),
                        Cidadeid = c.Int(nullable: false),
                        Nome = c.String(),
                        Ibge = c.Int(nullable: false),
                        Cpf = c.String(),
                        InscricaoEstadual = c.String(),
                        Logradouro = c.String(),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(),
                        Bairro = c.String(),
                        Estado = c.String(),
                        CEP = c.String(),
                        Telefone = c.String(),
                        Aniversario = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Cidades", t => t.Cidadeid, cascadeDelete: true)
                .ForeignKey("dbo.Logins", t => t.Loginid, cascadeDelete: true)
                .Index(t => t.Loginid)
                .Index(t => t.Cidadeid);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Senha = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Voluntarios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Loginid = c.Int(nullable: false),
                        Cidadeid = c.Int(nullable: false),
                        Nome = c.String(),
                        Cpf = c.String(),
                        InscricaoEstadual = c.String(),
                        Logradouro = c.String(),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(),
                        Bairro = c.String(),
                        Estado = c.String(),
                        Cep = c.String(),
                        Telefone = c.String(),
                        Aniversario = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Cidades", t => t.Cidadeid, cascadeDelete: true)
                .ForeignKey("dbo.Logins", t => t.Loginid, cascadeDelete: true)
                .Index(t => t.Loginid)
                .Index(t => t.Cidadeid);
            
            CreateTable(
                "dbo.ParticipaCampanhas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Status = c.Boolean(nullable: false),
                        Campanhaid = c.Int(nullable: false),
                        Voluntarioid = c.Int(nullable: false),
                        Entidadeid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Campanhas", t => t.Campanhaid, cascadeDelete: true)
                .ForeignKey("dbo.Entidades", t => t.Entidadeid, cascadeDelete: false)
                .ForeignKey("dbo.Voluntarios", t => t.Voluntarioid, cascadeDelete: false)
                .Index(t => t.Campanhaid)
                .Index(t => t.Voluntarioid)
                .Index(t => t.Entidadeid);
            
            CreateTable(
                "dbo.Doacaos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        ParticipaCampanhaid = c.Int(nullable: false),
                        Recursoid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.ParticipaCampanhas", t => t.ParticipaCampanhaid, cascadeDelete: false)
                .ForeignKey("dbo.Recursoes", t => t.Recursoid, cascadeDelete: true)
                .Index(t => t.ParticipaCampanhaid)
                .Index(t => t.Recursoid);
            
            CreateTable(
                "dbo.Recursoes",
                c => new

                    {
                        id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        TipoRecursoid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.TipoRecursoes", t => t.TipoRecursoid, cascadeDelete: true)
                .Index(t => t.TipoRecursoid);
            
            CreateTable(
                "dbo.TipoRecursoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Tipo = c.String(),
                    })
                .PrimaryKey(t => t.id);


            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VinculoAfinidades", "Campanhaid", "dbo.Campanhas");
            DropForeignKey("dbo.VinculoAfinidades", "Entidadeid", "dbo.Entidades");
            DropForeignKey("dbo.VinculoAfinidades", "Voluntarioid", "dbo.Voluntarios");
            DropForeignKey("dbo.ParticipaCampanhas", "Voluntarioid", "dbo.Voluntarios");
            DropForeignKey("dbo.ParticipaCampanhas", "Entidadeid", "dbo.Entidades");
            DropForeignKey("dbo.Recursoes", "TipoRecursoid", "dbo.TipoRecursoes");
            DropForeignKey("dbo.Doacaos", "Recursoid", "dbo.Recursoes");
            DropForeignKey("dbo.Doacaos", "ParticipaCampanhaid", "dbo.ParticipaCampanhas");
            DropForeignKey("dbo.ParticipaCampanhas", "Campanhaid", "dbo.Campanhas");
            DropForeignKey("dbo.Voluntarios", "Loginid", "dbo.Logins");
            DropForeignKey("dbo.Voluntarios", "Cidadeid", "dbo.Cidades");
            DropForeignKey("dbo.Governoes", "Loginid", "dbo.Logins");
            DropForeignKey("dbo.Entidades", "Loginid", "dbo.Logins");
            DropForeignKey("dbo.Governoes", "Cidadeid", "dbo.Cidades");
            DropForeignKey("dbo.Entidades", "Cidadeid", "dbo.Cidades");
            DropForeignKey("dbo.Campanhas", "Entidadeid", "dbo.Entidades");
            DropForeignKey("dbo.VinculoAfinidades", "Afinidadeid", "dbo.Afinidades");
            DropIndex("dbo.Recursoes", new[] { "TipoRecursoid" });
            DropIndex("dbo.Doacaos", new[] { "Recursoid" });
            DropIndex("dbo.Doacaos", new[] { "ParticipaCampanhaid" });
            DropIndex("dbo.ParticipaCampanhas", new[] { "Entidadeid" });
            DropIndex("dbo.ParticipaCampanhas", new[] { "Voluntarioid" });
            DropIndex("dbo.ParticipaCampanhas", new[] { "Campanhaid" });
            DropIndex("dbo.Voluntarios", new[] { "Cidadeid" });
            DropIndex("dbo.Voluntarios", new[] { "Loginid" });
            DropIndex("dbo.Governoes", new[] { "Cidadeid" });
            DropIndex("dbo.Governoes", new[] { "Loginid" });
            DropIndex("dbo.Entidades", new[] { "Cidadeid" });
            DropIndex("dbo.Entidades", new[] { "Loginid" });
            DropIndex("dbo.Campanhas", new[] { "Entidadeid" });
            DropIndex("dbo.VinculoAfinidades", new[] { "Campanhaid" });
            DropIndex("dbo.VinculoAfinidades", new[] { "Entidadeid" });
            DropIndex("dbo.VinculoAfinidades", new[] { "Voluntarioid" });
            DropIndex("dbo.VinculoAfinidades", new[] { "Afinidadeid" });
            DropTable("dbo.TipoRecursoes");
            DropTable("dbo.Recursoes");
            DropTable("dbo.Doacaos");
            DropTable("dbo.ParticipaCampanhas");
            DropTable("dbo.Voluntarios");
            DropTable("dbo.Logins");
            DropTable("dbo.Governoes");
            DropTable("dbo.Cidades");
            DropTable("dbo.Entidades");
            DropTable("dbo.Campanhas");
            DropTable("dbo.VinculoAfinidades");
            DropTable("dbo.Afinidades");
        }



    }
}
