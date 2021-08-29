using Microsoft.AspNetCore.SignalR.Client;
using RestApp.Commands;
using RestApp.Models;
using RestApp.Other;
using RestApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace RestApp.ViewModels
{
    public class UserViewModel : BaseInpc
    {
        public BaseInpc CurrentViewModel { get; }
        public string Title { get; set; }
        public ICommand ExitCommand { get; }
        NavigationService NavigationService { get; }

        public UserViewModel(UserModel user, NavigationService navigationService)
        {
            ExitCommand = new NavigateCommand<LoginViewModel>(navigationService, () => new LoginViewModel(navigationService), 1100.0, 1400.0);

            UserModel newUser = ConnectingToApi.Login(user).GetAwaiter().GetResult();

            HubConnection hubConnect = new HubConnectionBuilder()
                              .WithUrl("https://localhost:44339/OrdersHub")
                              .Build();

            if (user.Role == "Официант")
                CurrentViewModel = new WaiterViewModel(new SignalRService(hubConnect), newUser);
            else CurrentViewModel = new KitchenViewModel(new SignalRService(hubConnect));
            Title = "UserViewModel";
        }
    }
}
