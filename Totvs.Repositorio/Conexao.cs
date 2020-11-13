using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Totvs.Repositorio.Interfaces;

namespace Totvs.Repositorio
{
    public class Conexao : IConexao
    {
        private IConfiguration _config;
        public string GetConnection()
        {
            var connection = "Data Source=den1.mssql8.gear.host;Initial Catalog=tobrasil;User ID=tobrasil;Password=Bq6Q-_tgPTr0";
            return connection;
        }
        
    }
}
