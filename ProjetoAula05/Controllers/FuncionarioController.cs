using ProjetoAula05.Entities;
using ProjetoAula05.Enums;
using ProjetoAula05.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula05.Controllers
{
    /// <summary>
    /// Controlador para o fluxo de operações de funcionário
    /// </summary>
    public class FuncionarioController
    {
        public void CadastrarFuncionario()
        {
            try
            {
                Console.WriteLine("\n*** CADASTRO DE FUNCIONÁRIO ***\n");

                var funcionario = new Funcionario();

                Console.Write("ENTRE COM O NOME.............: ");
                funcionario.Nome = Console.ReadLine();

                Console.Write("ENTRE COM O CPF..............: ");
                funcionario.Cpf = Console.ReadLine();

                Console.Write("ENTRE COM A MATRICULA........: ");
                funcionario.Matricula = Console.ReadLine();

                Console.Write("ENTRE COM A DATA ADMISSÃO....: ");
                funcionario.DataAdmissao = DateTime.Parse(Console.ReadLine());

                Console.Write("ENTRE COM O STATUS (1,2,3,4).: ");
                funcionario.Status = (StatusFuncionario)int.Parse(Console.ReadLine());

                Console.Write("ENTRE COM O ID DA EMPRESA....: ");
                funcionario.IdEmpresa = Guid.Parse(Console.ReadLine());

                var funcionarioRepository = new FuncionarioRepository();
                funcionarioRepository.Inserir(funcionario);

                Console.WriteLine("\nFUNCIONÁRIO CADASTRADO COM SUCESSO.");
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

        public void ConsultarFuncionarios()
        {
            try
            {
                Console.WriteLine("\n***CONSULSTAR FUNCIONARIO***\n");

                var funcionarioRepository = new FuncionarioRepository();
                var funcionarios = funcionarioRepository.Consultar();

                foreach (var item in funcionarios)
                {
                    Console.WriteLine("ID.............: " + item.Id);
                    Console.WriteLine("NOME...........: " + item.Nome);
                    Console.WriteLine("CPF............: " + item.Cpf);
                    Console.WriteLine("MATRICULA......: " + item.Matricula);
                    Console.WriteLine("DATA ADMISSÃO..: " + item.DataAdmissao);
                    Console.WriteLine("STATUS.........: " + item.Status);
                    Console.WriteLine("ID DA EMPRESA..: " + item.Empresa.Id);
                    Console.WriteLine("NOME FANTASIA..: " + item.Empresa.NomeFantasia);
                    Console.WriteLine("RAZÃO SOCIAL...: " + item.Empresa.RazaoSocial);
                    Console.WriteLine("CNPJ...........: " + item.Empresa.Cnpj);
                    Console.WriteLine("...:");
                }


            }
            catch(Exception e)
            {
                Console.WriteLine("\nFalha:" + e.Message);
            }
        }
    }
}



