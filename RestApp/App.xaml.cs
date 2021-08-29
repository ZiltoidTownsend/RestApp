using Microsoft.AspNetCore.SignalR.Client;
using RestApp.Services;
using RestApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RestApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //HubConnection hubConnect = new HubConnectionBuilder()
            //                  .WithUrl("https://localhost:44384/chatHub")
            //                  .Build();

            //Waiter waiterWindow = new Waiter
            //{
            //    DataContext = new WaiterViewModel(new Services.SignalRService(hubConnect))
            //};

            //waiterWindow.Show();

            NavigationService navigationService = new NavigationService();

            navigationService.CurrentHeight = 650.0;
            navigationService.CurrentWidth = 800.0;
            navigationService.CurrentViewModel = new LoginViewModel(navigationService);


            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(navigationService),

            };
            MainWindow.Show();

            base.OnStartup(e);

        }


    }
}
