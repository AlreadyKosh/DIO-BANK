using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();

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
                        InserirContas();
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
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.ReadLine();
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o Numero da Conta");
            int numeroConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser Sacado");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[numeroConta].Sacar(valorSaque);
        }
        private static void Depositar()
        {
            Console.WriteLine("Digite o Numero da Conta");
            int numeroConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser Depositado");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[numeroConta].Depositar(valorDeposito);
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o Numero da Conta");
            int numeroConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Numero da Conta Destino");
            int numeroContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser Transferido");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[numeroConta].Transferir(valorTransferencia, listaContas[numeroContaDestino]);
        }

        private static void InserirContas()
        {
            Console.WriteLine("Inserir Nova Conta");
            Console.WriteLine("Digite 1 para conta fisica e digite 2 para  Juridica");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o Saldo a Conta");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Credito");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, saldo: entradaSaldo, credito: entradaCredito, nome: entradaNome);
            listaContas.Add(novaConta);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");
            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma Conta Cadastrada");
                return;
            }

            for (int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.WriteLine("# {0} - ", i);
                Console.WriteLine(conta);

            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor");
            Console.WriteLine("Informe a Opção Desejada!");

            Console.WriteLine("1: Lista de Contas Cadastradas");
            Console.WriteLine("2: Inserir Nova Conta");
            Console.WriteLine("3: Transferir");
            Console.WriteLine("4: Sacar");
            Console.WriteLine("5: Depositar");
            Console.WriteLine("C: Limpar Tela");
            Console.WriteLine("X: Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}
