using ByteBank.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;

namespace BankSystem {
    public class Program {
        public static void InitialMenu() {

            Console.ResetColor();
            Console.WriteLine(@"
╔══════════════════════════════╗
║    Sejam bem-vindos (as)     ║
║   ByteBank - SHARP CODERS    ║ 
║    O mundo nas suas mãos.    ║ 
╚══════════════════════════════╝
            ");
            
            Console.WriteLine();
            Console.WriteLine("Digite uma das opções abaixo de 0 a 6:");
            Console.WriteLine();
            Console.WriteLine("1 - Inserir novo usuário");
            Console.WriteLine("2 - Deletar um usuário");
            Console.WriteLine("3 - Listar todas as contas registradas");
            Console.WriteLine("4 - Detalhes de um usuário");
            Console.WriteLine("5 - Quantia armazenada no banco");
            Console.WriteLine("6 - Manipular a conta");
            Console.WriteLine("0 - Para sair do programa");
            Console.WriteLine();
            Console.Write("Digite a opção desejada: ");
        }
        public static void Main(string[] args) {

            List<string> cpfs = new List<string>();
            List<string> names = new List<string>();
            List<string> passwords = new List<string>();
            List<double> balances = new List<double>();

            while (true) {
                InitialMenu();

                // Validação da entrada do usuário
                if (!int.TryParse(Console.ReadLine(), out int option)) {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opção não válida. Por favor, digite um número de 0 a 6.");
                    Console.ResetColor();
                    continue;
                }

                switch (option) {
                    case 1:
                        Console.WriteLine();
                        RegistrarNovoUsuario.Registrar(cpfs, names, passwords, balances);
                        break;
                    case 2:
                        Console.WriteLine();
                        DeletarUsuario.Deletar(cpfs, names, passwords, balances);
                        break;
                    case 3:
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        ListarTodasAsContas.Listar(cpfs, names, passwords, balances);
                        Console.ResetColor();
                        break;
                    case 4:
                        Console.WriteLine();
                        ApresentarUsuario.Apresentar(cpfs, names, passwords, balances);
                        break;
                    case 5:
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        ApresentarValorAcumulado.Apresentar(balances);
                        Console.ResetColor();
                        break;
                    case 6:
                        Console.Clear();
                        Submenu.ManipularConta(cpfs, names, passwords, balances);
                        break;
                    case 0:
                        Console.WriteLine("Agradecemos pela preferência do nosso ByteBank!");
                        break;
                    default:
                        Console.WriteLine("Opção não válida. Por favor, digite um número de 0 a 6.");
                        break;
                }
            }
        }
    }
}
