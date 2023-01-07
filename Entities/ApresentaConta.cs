using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Entities {
    class ApresentaConta {
        public static void Apresentar(List<string> cpfs, List<string> names, List<string> passwords, List<double> balances, int index) {
            Console.WriteLine("CPF: " + cpfs[index]);
            Console.WriteLine("Nome: " + names[index]);
            Console.WriteLine($"Saldo: {balances[index]:C}");
        }
    }
}

