using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.PresentationLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace iQuest.VendingMachine.UseCases
{
    internal class BuyProductUseCase : IUseCase
    {
        private readonly BuyProductView bpv = new BuyProductView();
        Dictionary<int, Product> chooseProduct;
        private int number;
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }

        private readonly AuthenticationService authentication = new AuthenticationService();
        public string Name => "Buy a product";

        public string Description => "You can buy anything you want\n";

        public bool CanExecute => authentication.IsUserAuthenticated == false;

        public void Steal(Dictionary<int, Product> items)
        {
            chooseProduct = items;
        }
        public BuyProductUseCase (AuthenticationService As)
        {
            authentication = As;
        }
        public void Execute()
        {
            try
            {
                Number = Convert.ToInt32(bpv.BuyProduct());
            }
            catch
            {
                Console.WriteLine("Invalid number");
                return;
            }
            //if (!Char.IsDigit(Convert.ToChar(Number)) || Number > chooseProduct.Count || Number < 0)
            //{
            //    Console.WriteLine("Invalid number");
            //    return;
            //}
            try
            {
                Console.WriteLine("You have chosen:" + chooseProduct[Number].Name + " Proceed? ([y]es/[n]o)");
            }
            catch
            {
                Console.WriteLine("Sorry bud, we don't have this many products\n");
                return;
            }
            char d;
            try
            {
                 d = Convert.ToChar(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please write a character next time\n");
                return;
            }
            if (d == 'y' || d == 'Y')
            {
                if (chooseProduct[Number].Count == 0)
                {
                    Console.WriteLine("Insufficient stock\n");
                    return;
                }
                PayUseCase puc = new PayUseCase();
                puc.Allowance(d);
                if (!puc.CanExecute)
                {
                    Console.WriteLine("Not allowed\n");
                    return;
                }
                puc.Borrow(chooseProduct[Number]);
                puc.Execute();
                chooseProduct[Number] = puc.ReturnBackItem();
            }
            else
            {
                Console.WriteLine("Canceled\n");
                return;
            }

        }
    }
}
