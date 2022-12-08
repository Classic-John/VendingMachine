using iQuest.VendingMachine.UseCases;
using System;

namespace iQuest.VendingMachine
{

    struct Product
    {
        private string name;
        private int count;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
       public string returnName() 
        {
            return name;
        }
        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
            }
        }
        public Product(string name)
        {
            Name = name;
        }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Bootstrapper bootstrapper = new Bootstrapper();
                bootstrapper.Run();
            }
            catch (Exception ex)
            {
                DisplayError(ex);
                Pause();
            }
        }

        private static void DisplayError(Exception ex)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex);
            Console.ForegroundColor = oldColor;
        }

        private static void Pause()
        {
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
            Console.WriteLine();
        }
    }
}