using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Entities {
    class ListarTodasAsContas {
        public static void Listar(List<string> cpfs, List<string> names, List<string> passwords, List<double> balances) {
            if (cpfs.Count == 0) {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("Não existem contas cadastradas.");
            }

            for (int i = 0; i < cpfs.Count; i++) {
                ApresentaConta.Apresentar(cpfs, names, passwords, balances, i);
                Console.WriteLine();
            }
        }
    }
}
