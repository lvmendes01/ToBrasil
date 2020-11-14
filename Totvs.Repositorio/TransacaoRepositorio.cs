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
    public class TransacaoRepositorio : ITransacaoRepositorio
    {
        IConexao conexao;
        public TransacaoRepositorio(IConexao configuration)
        {
            conexao = configuration;
        }

        public string Atualizar(Transacao o)
        {
            var connectionString = this.conexao.GetConnection();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "UPDATE [dbo].[Transacaos] " +
                        "SET DataTransacao = @DataTransacao," +
                        " ValorCompra = @ValorCompra " +
                        " ValorEntregue = @ValorEntregue " +
                        " ValorTroco = @ValorTroco " +
                        " Observacao = @Observacao " +
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

        public Transacao Carregar(long i)
        {
            var connectionString = this.conexao.GetConnection();
            Transacao item = new Transacao();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM [dbo].[Transacaos] WHERE Id =" + i;
                    item = con.Query<Transacao>(query).FirstOrDefault();
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

        public string Delete(Transacao o)
        {
            var connectionString = this.conexao.GetConnection();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "DELETE FROM [dbo].[Transacaos] WHERE Id =" + o.Id;
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

        public IList<Transacao> Listar()
        {
            var connectionString = this.conexao.GetConnection();
            List<Transacao> lista = new List<Transacao>();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM [dbo].[Transacaos]";
                    lista = con.Query<Transacao>(query).ToList();
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

        public string Salvar(Transacao o)
        {
            var connectionString = this.conexao.GetConnection();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "INSERT INTO [dbo].[Transacaos]" +
                        "([ValorCompra],[DataTransacao],[ValorEntregue],[ValorTroco],[Observacao]) VALUES" +
                        "(@ValorCompra, @DataTransacao, @ValorEntregue, @ValorTroco, @Observacao); SELECT CAST(SCOPE_IDENTITY() as INT); ";
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
                return count == 1 ? "Ok" : "";
            }
        }
    }
}
