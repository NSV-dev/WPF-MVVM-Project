using MVVM1.ViewModels.Base;
using System;

namespace MVVM1.Infrastructure.Stores
{
    public class NavigationStore
    {
        private IControlViewModel _currentViewModel;

        public IControlViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public event Action CurrentViewModelChanged;

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
