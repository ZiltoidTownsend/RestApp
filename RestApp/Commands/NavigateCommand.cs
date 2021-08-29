using RestApp.Services;
using RestApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestApp.Commands
{
    public class NavigateCommand<TViewModel> : CommandBase
        where TViewModel : BaseInpc
    {
        private NavigationService _navigationService;
        private Func<TViewModel> _createViewModel;
        private double Height;
        private double Width;

        public NavigateCommand(NavigationService navigationService, Func<TViewModel> createViewModel, double height, double width)
        {
            _navigationService = navigationService;
            _createViewModel = createViewModel;
            Height = height;
            Width = width;
        }
        public override void Execute(object parameter)
        {
            _navigationService.CurrentViewModel = _createViewModel();
            _navigationService.CurrentWidth = Width;
            _navigationService.CurrentHeight = Height;
        }
    }
}
