using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Totvs.Entidade
{
    public class CadastroContext : DbContext
    {
        public CadastroContext() : base("Data Source=den1.mssql8.gear.host;Initial Catalog=tobrasil;User ID=tobrasil;Password=Bq6Q-_tgPTr0")
        {
            // Database.SetInitializer<SchoolDBContext>(new CreateDatabaseIfNotExists<SchoolDBContext>());

            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseIfModelChanges<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseAlways<SchoolDBContext>());

        }
        public void FixEfProviderServicesProblem()
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public DbSet<Moedas> TB_Moedas { get; set; }
        public DbSet<Notas> TB_Notas { get; set; }
        public DbSet<Transacao> TB_Transacao { get; set; }
    }
}
