namespace Totvs.Entidade.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bds : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Moedas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Valor = c.Double(nullable: false),
                        Qtd = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Valor = c.Double(nullable: false),
                        Qtd = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transacaos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DataTransacao = c.DateTime(nullable: false),
                        ValorCompra = c.Double(nullable: false),
                        ValorEntregue = c.Double(nullable: false),
                        ValorTroco = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TransacaoMoedas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TransacaoId = c.Long(nullable: false),
                        MoedaId = c.Long(nullable: false),
                        Qtdade = c.Long(nullable: false),
                        DataRegistro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Transacaos", t => t.TransacaoId, cascadeDelete: true)
                .Index(t => t.TransacaoId);
            
            CreateTable(
                "dbo.TransacaoNotas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TransacaoId = c.Long(nullable: false),
                        NotaId = c.Long(nullable: false),
                        Qtdade = c.Long(nullable: false),
                        DataRegistro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Transacaos", t => t.TransacaoId, cascadeDelete: true)
                .Index(t => t.TransacaoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransacaoNotas", "TransacaoId", "dbo.Transacaos");
            DropForeignKey("dbo.TransacaoMoedas", "TransacaoId", "dbo.Transacaos");
            DropIndex("dbo.TransacaoNotas", new[] { "TransacaoId" });
            DropIndex("dbo.TransacaoMoedas", new[] { "TransacaoId" });
            DropTable("dbo.TransacaoNotas");
            DropTable("dbo.TransacaoMoedas");
            DropTable("dbo.Transacaos");
            DropTable("dbo.Notas");
            DropTable("dbo.Moedas");
        }
    }
}
