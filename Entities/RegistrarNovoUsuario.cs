using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Entities {
    class RegistrarNovoUsuario {
        public static void Registrar(List<string> cpfs, List<string> names, List<string> passwords, List<double> balances) {
            //foreach (name obj in names) {

            Console.Write("Digite o CPF do novo titular: ");
            string cpf = Console.ReadLine();
            if (!cpfs.Contains(cpf)) {
                cpfs.Add(cpf);
                Console.Write("Digite o nome do novo titular: ");
                names.Add(Console.ReadLine());
                Console.Write("Digite a senha do novo titular: ");
                passwords.Add(Console.ReadLine());
                balances.Add(0);
                Console.WriteLine();
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Parabéns cadastrado com sucesso!");
                Console.WriteLine();
            }
            else {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("CPF informado já está sendo usado em outra conta.");
            }
        }
    }
}
