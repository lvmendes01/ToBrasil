using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using Totvs.Entidade;
using System;
using System.Linq;
using Totvs.Repositorio.Interfaces;

namespace Totvs.Repositorio
{
    public class NotasRepositorio : INotasRepositorio
    {
        IConexao conexao;
        public NotasRepositorio(IConexao configuration)
        {
            conexao = configuration;
        }

        public string Atualizar(Notas o)
        {
            var connectionString = this.conexao.GetConnection();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "UPDATE [dbo].[Notas] " +
                        "SET  Qtd = @Qtd " +
                        "WHERE Id = " + o.Id;
                    count = con.Execute(query, o);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count.ToString();
            }
        }

        public Notas Carregar(long i)
        {
            var connectionString =  this.conexao.GetConnection();
            Notas item = new Notas();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM [dbo].[Notas] WHERE Id =" + i;
                    item = con.Query<Notas>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return item;
            }
        }

        public string Delete(Notas o)
        {
            var connectionString =  this.conexao.GetConnection();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "DELETE FROM [dbo].[Notas] WHERE Id =" + o.Id;
                    count = con.Execute(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count.ToString();
            }
        }

        public IList<Notas> Listar()
        {
            var connectionString =  this.conexao.GetConnection();
            List<Notas> lista = new List<Notas>();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM [dbo].[Notas]";
                    lista = con.Query<Notas>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return lista;
            }
        }

        public string Salvar(Notas o)
        {
            var connectionString =  this.conexao.GetConnection();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {

                    con.Open();
                    var query = "INSERT INTO [dbo].[Notas]([Valor],[Qtd]) VALUES(@Valor, @Qtd); SELECT CAST(SCOPE_IDENTITY() as INT); ";
                    count = con.Execute(query, o);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count == 1? "Ok": "";
            }
        }
    }
}
