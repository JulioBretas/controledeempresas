using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula05.Configurations
{
    /// <summary>
    /// Classe para mapeamento das configurações de acesso ao SqlServer
    /// </summary>
    public class SqlServerConfiguration
    {
        public static string ConnectionString {
            get => @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDAula05;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
    }
}
