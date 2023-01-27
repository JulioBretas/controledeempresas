using Dapper;
using ProjetoAula05.Configurations;
using ProjetoAula05.Entities;
using ProjetoAula05.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula05.Repositories
{
    /// <summary>
    /// Repositório de dados para Empresa
    /// </summary>
    public class EmpresaRepository : IRepository<Empresa>
    {
        public void Inserir(Empresa obj)
        {
            var query = @"
                INSERT INTO EMPRESA(ID, NOMEFANTASIA, RAZAOSOCIAL, CNPJ)
                VALUES(@Id, @NomeFantasia, @RazaoSocial, @Cnpj)
            ";

            using (var connection = new SqlConnection(SqlServerConfiguration.ConnectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public List<Empresa> Consultar()
        {
            var query = @"
                SELECT * FROM EMPRESA
                ORDER BY NOMEFANTASIA
            ";

            using (var connection = new SqlConnection(SqlServerConfiguration.ConnectionString))
            {
                return connection.Query<Empresa>(query).ToList();
            }
        }
    }
}
