using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iQuest.VendingMachine.Authentication;

namespace iQuest.VendingMachine.UseCases
{
    internal class PayUseCase : IUseCase
    {
        bool allowance;
        char method;
        Product p;
        public string Name => "Pay";

        public string Description => "Allows you to pay for the product\n";

        public bool Allowance(char d)
        {
            if (d == 'y' || d == 'Y')
            {
                allowance = true;
            }
            else
            {
                allowance = false;
            }
            return allowance;
        }
        public bool CanExecute => allowance == true;
        public void Borrow(Product p)
        {
            this.p= p;
        }
        public Product ReturnBackItem()
        {
            return p;
        }
        public void Execute()
        {
            Console.WriteLine("[C]ard or [c]ash?\n");
            try
            {
                method = Convert.ToChar(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please write a character next time\n");
                return;
            }
            if(method =='C' || method=='c')
            {
                Console.WriteLine("Payment succeded\n");
                p.Count--;
            }
            else 
            {
                Console.WriteLine("Payment cancelled\n");
                return;
            }
        }
    }
}
