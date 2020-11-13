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
    public class MoedasRepositorio : IMoedasRepositorio
    {
        IConexao conexao;
        public MoedasRepositorio(IConexao configuration)
        {
            conexao = configuration;
        }

        public string Atualizar(Moedas o)
        {
            var connectionString = this.conexao.GetConnection();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "UPDATE Produtos SET Name = @Nome, Estoque = @Estoque, Preco = @Preco WHERE ProdutoId = " + o.Id;
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

        public Moedas Carregar(long i)
        {
            var connectionString =  this.conexao.GetConnection();
            Moedas produto = new Moedas();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Produtos WHERE ProdutoId =" + i;
                    produto = con.Query<Moedas>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return produto;
            }
        }

        public string Delete(Moedas o)
        {
            var connectionString =  this.conexao.GetConnection();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "DELETE FROM Produtos WHERE ProdutoId =" + o.Id;
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

        public IList<Moedas> Listar()
        {
            var connectionString =  this.conexao.GetConnection();
            List<Moedas> produtos = new List<Moedas>();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM [dbo].[Moedas]";
                    produtos = con.Query<Moedas>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return produtos;
            }
        }

        public string Salvar(Moedas o)
        {
            var connectionString =  this.conexao.GetConnection();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {

                    con.Open();
                    var query = "INSERT INTO [dbo].[Moedas]([Valor],[Qtd]) VALUES(@Valor, @Qtd); SELECT CAST(SCOPE_IDENTITY() as INT); ";
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
