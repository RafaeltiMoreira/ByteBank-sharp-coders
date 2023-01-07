using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Entities {
    class ApresentarUsuario {
        public static void Apresentar(List<string> cpfs, List<string> names, List<string> passwords, List<double> balances) {
            Console.Write("Digite o CPF da conta que deseja visualizar: ");
            string cpf = Console.ReadLine();
            int index = cpfs.IndexOf(cpf);
            if (index != -1) {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                ApresentaConta.Apresentar(cpfs, names, passwords, balances, index);
                Console.ResetColor();
            }
            else {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("CPF não válido ou não encontrado.");
            }
        }
    }
}
