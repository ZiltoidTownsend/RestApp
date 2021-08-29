using LibraryMenu;
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
    public class LoginViewModel : BaseInpc
    {
        public string Title { get; }
        public UserModel User { get; set; } = new UserModel {Login = "Asduqj123_a", Password= "Asduqwe123_jj" };

        private string answer;

        public string Answer { get => answer; set => Set(ref answer, value); }
        public ICommand NavigateWaiterCommand { get; }

        private RelayCommand registrationCommand;
        public RelayCommand RegistrationCommand => registrationCommand
    ?? (registrationCommand = new RelayCommand<UserModel>(RegistrationExecute));

        private void RegistrationExecute(UserModel user)
        {
            //UserModel newUser = new UserModel{ Login = user.Login, Password = user.Password };
            UserModel newUser = ConnectingToApi.Registration(user).GetAwaiter().GetResult();
        }
        public LoginViewModel(NavigationService navigationService)
        {
            Title = "Login";
            NavigateWaiterCommand = new NavigateCommand<UserViewModel>(navigationService, () => new UserViewModel(User, navigationService), 1100.0, 1400.0);
        }
    }
}
