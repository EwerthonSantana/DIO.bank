using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("Escolha inválida!");
                        break;
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.ReadKey();
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.WriteLine("Escolha o tipo da conta -> Física(1)   Jurídica(2)   ONG(3)  Governamental(4)");
            int entradaTipoConta = int.Parse(Console.ReadLine());
                  
            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            decimal entradaSaldo = decimal.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            decimal entradaCredito = decimal.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                         nome: entradaNome,
                                         credito: entradaCredito,
                                         saldo: entradaSaldo);

            listContas.Add(novaConta);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");
            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }
            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("\nOlá, seja muito bem-vindo ao Dio bank! :)");
            Console.WriteLine("Informe a opção que deseja executar: ");
            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Tranferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        public static void Sacar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int indeciConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado: ");
            decimal valorSaque = decimal.Parse(Console.ReadLine());

            listContas[indeciConta].Sacar(valorSaque);
        }

        public static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiciConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser depositado: ");
            decimal valorDeposito = decimal.Parse(Console.ReadLine());

            listContas[indiciConta].Depositar(valorDeposito);
        }

        public static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta destino: ");
            int indiceDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser tranferido: ");
            decimal valorTransferencia = decimal.Parse(Console.ReadLine());

            listContas[indiceOrigem].Transferir(valorTransferencia, listContas[indiceDestino]);
        }
    }
}
