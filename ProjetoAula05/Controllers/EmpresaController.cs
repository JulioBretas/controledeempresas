using ProjetoAula05.Entities;
using ProjetoAula05.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula05.Controllers
{
    /// <summary>
    /// Controlador para o fluxo de operações de empresa
    /// </summary>
    public class EmpresaController
    {
        public void CadastrarEmpresa()
        {
            try
            {
                Console.WriteLine("\n*** CADASTRO DE EMPRESA ***\n");

                var empresa = new Empresa();
                empresa.Id = Guid.NewGuid();

                Console.Write("ENTRE COM O NOME FANTASIA..: ");
                empresa.NomeFantasia = Console.ReadLine();

                Console.Write("ENTRE COM A RAZÃO SOCIAL...: ");
                empresa.RazaoSocial = Console.ReadLine();

                Console.Write("ENTRE COM O CNPJ...........: ");
                empresa.Cnpj = Console.ReadLine();

                var empresaRepository = new EmpresaRepository();
                empresaRepository.Inserir(empresa);

                Console.WriteLine("\nEMPRESA CADASTRADA COM SUCESSO!");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("\nErro de validação: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nFalha: " + e.Message);
            }
        }

        public void ConsultarEmpresas()
        {
            try
            {
                Console.WriteLine("\n*** CONSULTA DE EMPRESAS ***\n");

                var empresaRepository = new EmpresaRepository();
                var empresas = empresaRepository.Consultar();

                foreach (var item in empresas)
                {
                    Console.WriteLine("ID..............: " + item.Id);
                    Console.WriteLine("NOME FANTASIA...: " + item.NomeFantasia);
                    Console.WriteLine("RAZÃO SOCIAL....: " + item.RazaoSocial);
                    Console.WriteLine("CNPJ............: " + item.Cnpj);
                    Console.WriteLine("...");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("\nFalha: " + e.Message);
            }
        }
    }
}
