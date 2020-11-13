using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Totvs.Repositorio.Interfaces
{
     public interface IConexao
    {
        string GetConnection();
    }
}
