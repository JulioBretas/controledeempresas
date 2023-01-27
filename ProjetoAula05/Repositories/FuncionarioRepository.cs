using Dapper;
using ProjetoAula05.Configurations;
using ProjetoAula05.Entities;
using ProjetoAula05.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula05.Repositories
{
    /// <summary>
    /// Repositório de dados para Funcionário
    /// </summary>
    public class FuncionarioRepository : IRepository<Funcionario>
    {
        public void Inserir(Funcionario obj)
        {
            using (var connection = new SqlConnection(SqlServerConfiguration.ConnectionString))
            {
                connection.Execute(
                    "SP_INSERIR_FUNCIONARIO",
                    new
                    {
                        @P_NOME = obj.Nome,
                        @P_CPF = obj.Cpf,
                        @P_MATRICULA = obj.Matricula,
                        @P_DATAADMISSAO = obj.DataAdmissao,
                        @P_STATUS = (int)obj.Status,
                        @P_IDEMPRESA = obj.IdEmpresa
                    },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public List<Funcionario> Consultar()
        {
            var query = @"
                SELECT * FROM 
                    FUNCIONARIO f
                    INNER JOIN EMPRESA e
                ON
                    e.ID = f.IDEMPRESA
                ORDER BY f.NOME   
            ";

            using (var connection = new SqlConnection(SqlServerConfiguration.ConnectionString))
            {
                return connection.Query
                    (query, 
                    (Funcionario f, Empresa e) => { f.Empresa = e; return f; },
                    splitOn: "IdEmpresa")
                    .ToList();
            }
        }
    }
}

