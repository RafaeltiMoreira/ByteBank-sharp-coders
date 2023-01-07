using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Entities {
    class DeletarUsuario {
        public static void Deletar(List<string> cpfs, List<string> names, List<string> passwords, List<double> balances) {
            Console.Write("Digite o CPF da conta que deseja excluir: ");
            string cpf = Console.ReadLine();
            int index = cpfs.IndexOf(cpf);
            if (index != -1) {
                cpfs.RemoveAt(index);
                names.RemoveAt(index);
                passwords.RemoveAt(index);
                balances.RemoveAt(index);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine("Conta excluída com sucesso!");
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