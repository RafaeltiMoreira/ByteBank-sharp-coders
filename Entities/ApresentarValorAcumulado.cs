using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Entities {
    class ApresentarValorAcumulado {
        public static void Apresentar(List<double> balances) {
            double total = balances.Sum();
            Console.WriteLine($"Quantia total armazenada no banco: {total:C}");
        }
    }
}
