using RestApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestApp.ViewModels
{
    public class MainWindowViewModel : BaseInpc
    { 

        public readonly NavigationService _navigationService;
        public BaseInpc CurrentViewModel => _navigationService.CurrentViewModel;

        public double Width => _navigationService.CurrentWidth;
        public double Height => _navigationService.CurrentHeight;

        public MainWindowViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;
            _navigationService.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _navigationService.CurrentHeightChanged += OnCurrentHeightChanged;
            _navigationService.CurrentWidthChanged += OnCurrentWidthChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            RaisePropertyChanged(nameof(CurrentViewModel));
        }
        private void OnCurrentWidthChanged()
        {
            RaisePropertyChanged(nameof(Width));

        }
        private void OnCurrentHeightChanged()
        {
            RaisePropertyChanged(nameof(Height));

        }
    }
}
