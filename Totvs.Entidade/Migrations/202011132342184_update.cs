namespace Totvs.Entidade.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TransacaoMoedas", "TransacaoId", "dbo.Transacaos");
            DropForeignKey("dbo.TransacaoNotas", "TransacaoId", "dbo.Transacaos");
            DropIndex("dbo.TransacaoMoedas", new[] { "TransacaoId" });
            DropIndex("dbo.TransacaoNotas", new[] { "TransacaoId" });
            DropTable("dbo.TransacaoMoedas");
            DropTable("dbo.TransacaoNotas");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.TransacaoNotas", "TransacaoId");
            CreateIndex("dbo.TransacaoMoedas", "TransacaoId");
            AddForeignKey("dbo.TransacaoNotas", "TransacaoId", "dbo.Transacaos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TransacaoMoedas", "TransacaoId", "dbo.Transacaos", "Id", cascadeDelete: true);
        }
    }
}
