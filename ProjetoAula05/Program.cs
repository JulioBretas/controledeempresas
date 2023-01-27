using ProjetoAula05.Controllers;

namespace ProjetoAula05
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\n*** CONTROLE DE EMPRESAS E FUNCIONÁRIOS ***\n");

            Console.WriteLine("(1) CADASTRAR EMPRESAS");
            Console.WriteLine("(2) CONSULTAR EMPRESAS");
            Console.WriteLine("(3) CADASTRAR FUNCIONÁRIOS");
            Console.WriteLine("(4) CONSULTAR FUNCIONÁRIOS");

            Console.Write("\nENTRE COM A OPÇÃO DESEJADA..: ");
            var opcao = int.Parse(Console.ReadLine());

            var empresaController = new EmpresaController();
            var funcionarioController = new FuncionarioController();

            switch (opcao)
            {
                case 1:
                    empresaController.CadastrarEmpresa();
                    break;

                case 2:
                    empresaController.ConsultarEmpresas();
                    break;

                case 3:
                    funcionarioController.CadastrarFuncionario();
                    break;

                case 4:
                    funcionarioController.ConsultarFuncionarios();
                    break;

                default:
                    Console.WriteLine("\nOPÇÃO INVÁLIDA.");
                    break;

            }

            Console.Write("\nDESEJA CONTINUAR? (S,N)..: ");
            var escolha = Console.ReadLine();

            if (escolha.Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear(); //limpar o console
                Main(args); //recursividade
            }
            else
            {
                Console.WriteLine("\nFIM DO PROGRAMA!");
                Console.ReadKey();
            }
        }
    }
}




