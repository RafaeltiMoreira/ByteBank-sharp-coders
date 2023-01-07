using BankSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Entities {
    class Submenu {
        public static void ManipularConta(List<string> cpfs, List<string> names, List<string> passwords, List<double> balances) {

            bool sair = false;
            bool logIn = false;
            int logInIndex = -1;
            while (!sair) {

                Console.WriteLine(@"
╔══════════════════════════════╗
║   ByteBank - SHARP CODERS    ║
╚══════════════════════════════╝
            ");
                Console.WriteLine("Para transações digite uma opção de 1 a 6: ");
                Console.WriteLine("1 - Fazer login");
                Console.WriteLine("2 - Sacar");
                Console.WriteLine("3 - Depositar");
                Console.WriteLine("4 - Transferir");
                Console.WriteLine("5 - Fazer logout");
                Console.WriteLine("6 - Voltar ao menu inicial");
                Console.WriteLine();
                Console.Write("Digite a opção desejada: ");

                try {
                    int option = int.Parse(Console.ReadLine());
                    switch (option) {
                        case 1:
                            if (logIn) {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine();
                                Console.WriteLine($"Usuário logado para realizar transações!");
                                Console.ResetColor();
                            }
                            else {
                                Console.Write("Digite o CPF da conta: ");
                                string cpf = Console.ReadLine();
                                int index = cpfs.IndexOf(cpf);
                                if (index != -1) {
                                    Console.Write("Digite a senha da conta: ");
                                    string password = Console.ReadLine();
                                    if (password == passwords[index]) {
                                        logIn = true;
                                        logInIndex = index;
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine();
                                        Console.WriteLine("Login realizado com sucesso!");
                                        Console.ResetColor();
                                    }
                                    else {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine();
                                        Console.WriteLine("Senha incorreta.");
                                        Console.ResetColor();
                                    }
                                }
                                else {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine();
                                    Console.WriteLine("CPF não válido ou não encontrado.");
                                    Console.ResetColor();
                                }
                            }
                            break;
                        case 2:
                            if (!logIn) {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine();
                                Console.WriteLine("Você precisa estar logado para realizar uma transação!");
                                Console.ResetColor();
                            }
                            else {
                                Console.Write("Digite a quantia a ser sacada R$ ");
                                double sacarQuantia = double.Parse(Console.ReadLine());
                                if (sacarQuantia > balances[logInIndex]) {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine();
                                    Console.WriteLine($"Saldo insuficiente. Seu saldo atual: {balances[logInIndex]:C}");
                                    Console.ResetColor();
                                }
                                else {
                                    balances[logInIndex] -= sacarQuantia;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine();
                                    Console.WriteLine($"Saque de R$ {sacarQuantia:C} realizado com sucesso! Seu novo saldo é de R$ {balances[logInIndex]:C}");
                                    Console.ResetColor();
                                }
                            }
                            break;
                        case 3:
                            if (!logIn) {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine();
                                Console.WriteLine("Você precisa estar logado para realizar uma transação!");
                                Console.ResetColor();
                            }
                            else {
                                Console.Write("Digite a quantia a ser depositada R$ ");
                                double depositoQuantia = double.Parse(Console.ReadLine());
                                balances[logInIndex] += depositoQuantia;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine();
                                Console.WriteLine($"Depósito de {depositoQuantia:C} realizado com sucesso! Seu novo saldo é de {balances[logInIndex]:C}");
                                Console.ResetColor();
                            }
                            break;
                        case 4:
                            if (!logIn) {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine();
                                Console.WriteLine("Você precisa estar logado para realizar uma transação!");
                                Console.ResetColor();
                            }
                            else {
                                Console.Write("Digite o CPF da conta de destino: ");
                                string cpf = Console.ReadLine();
                                int index = cpfs.IndexOf(cpf);
                                if (index != -1) {
                                    Console.Write("Digite a quantia a ser transferida R$ ");
                                    double transferQuantia = double.Parse(Console.ReadLine());
                                    if (balances[logInIndex] >= transferQuantia) {
                                        balances[logInIndex] -= transferQuantia;
                                        balances[index] += transferQuantia;

                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine();
                                        Console.WriteLine($"Transferência de {transferQuantia:C} realizada com sucesso! Seu novo saldo é de {balances[logInIndex]:C}");
                                        Console.ResetColor();
                                    }
                                    else {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine();
                                        Console.WriteLine($"Saldo insuficiente. Seu saldo atual: {balances[logInIndex]:C}");
                                        Console.ResetColor();
                                    }
                                }
                                else {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine();
                                    Console.WriteLine("CPF de destino inválido ou não encontrado.");
                                    Console.ResetColor();
                                }
                            }
                            break;
                        case 5:
                            if (!logIn) {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine();
                                Console.WriteLine("O usuário não está logado!");
                                Console.ResetColor();
                            }
                            else {
                                logIn = false;
                                logInIndex = -1;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine();
                                Console.WriteLine("Logout realizado com sucesso!");
                                Console.ResetColor();
                            }
                            break;
                        case 6:
                            Program.InitialMenu();
                            Console.Clear();
                            sair = true;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine();
                            Console.WriteLine("Opção inválida.");
                            Console.ResetColor();
                            break;
                    }
                }
                catch (FormatException) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("Por favor, insira um número válido de 1 a 6.");
                    Console.ResetColor();
                }
            }
        }
    }
}