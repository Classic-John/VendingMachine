using System;

namespace iQuest.VendingMachine.Authentication
{
    internal class AuthenticationService
    {
        public bool IsUserAuthenticated { get; private set; }

        public void Login(string password)
        {
            try
            {
                if (password == "candyshop")
                {
                    IsUserAuthenticated = true;
                }
            }
            catch
            {
                Console.WriteLine("Error\n");
                return;
            }
            Console.WriteLine("Wrong password\n");
            return;
        }

        public void Logout()
        {
            IsUserAuthenticated = false;
        }
    }
}