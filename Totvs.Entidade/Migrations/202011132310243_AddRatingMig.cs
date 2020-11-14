namespace Totvs.Entidade.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRatingMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transacaos", "Observacao", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transacaos", "Observacao");
        }
    }
}
