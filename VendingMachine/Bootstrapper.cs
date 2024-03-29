﻿using System.Collections.Generic;
using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.UseCases;

namespace iQuest.VendingMachine
{
    internal class Bootstrapper
    {
        public void Run()
        {
            VendingMachineApplication vendingMachineApplication = BuildApplication();
            vendingMachineApplication.Run();
        }

        private static VendingMachineApplication BuildApplication()
        {
            MainView mainView = new MainView();
            LoginView loginView = new LoginView();

            AuthenticationService authenticationService = new AuthenticationService();

            BuyProductUseCase bpuc = new(authenticationService);
            LookAtShelfUseCase lasuc = new();
            lasuc.ReadData();
            bpuc.Steal(lasuc.GetProducts());
            List<IUseCase> useCases = new List<IUseCase>
            {
                new LoginUseCase(authenticationService, loginView),
                new LogoutUseCase(authenticationService),
                lasuc,
                bpuc
            };

            return new VendingMachineApplication(useCases, mainView);
        }
    }
}