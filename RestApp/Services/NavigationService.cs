using RestApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestApp.Services
{
    public class NavigationService
    {
        public event Action CurrentWidthChanged;
        public event Action CurrentHeightChanged;
        public event Action CurrentViewModelChanged;

        private double _currentWidth;
        private double _currentHeight;
        private BaseInpc _currentViewModel;

        public double CurrentWidth
        {
            get => _currentWidth;
            set
            {
                _currentWidth = value;
                OnCurrentWidthChanged();
            }
        }
        public double CurrentHeight
        {
            get => _currentHeight;
            set
            {
                _currentHeight = value;
                OnCurrentHeightChanged();
            }
        }
        public BaseInpc CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
        private void OnCurrentWidthChanged()
        {
            CurrentWidthChanged?.Invoke();
        }
        private void OnCurrentHeightChanged()
        {
            CurrentHeightChanged?.Invoke();
        }
    }
}
