using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQuest.VendingMachine.UseCases
{
    internal class LookAtShelfUseCase : IUseCase
    {
        Dictionary<int, Product> products= new();
        public string Name => "Look at shelf";

        public string Description => "You can look what products are available";

        public bool CanExecute=>true;

        public Dictionary<int, Product> GetProducts()
        {
            return products;
        }
        public void ReadData()
        {
            products.Add(products.Count, new Product() { Count = 4, Name = "Snickers" });
            products.Add(products.Count, new Product() { Count = 1, Name = "Mars" });
            products.Add(products.Count, new Product() { Count = 10, Name = "Pizza" });
        }
        public void Execute()
        {
            int k = 0;
            if(products.Count==0)
            {
                Console.WriteLine("Nothing to show on the vending machine\n");
                return;
            }
            foreach (var p in products)
            {
                Console.WriteLine(k++ + ":" + p.Value.returnName()+"\n");
            }
        }
    }
}
