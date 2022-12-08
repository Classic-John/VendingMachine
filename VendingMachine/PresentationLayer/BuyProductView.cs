using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class BuyProductView:DisplayBase
    {
        public string BuyProduct()
        {
            Console.WriteLine();
            Display("Choose a product:", ConsoleColor.Cyan);
            return Console.ReadLine();
        }
    }
}
