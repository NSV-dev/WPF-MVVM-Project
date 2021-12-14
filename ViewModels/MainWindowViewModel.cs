using MVVM1.Infrastructure.Commands.Base;
using MVVM1.Infrastructure.Stores;
using MVVM1.ViewModels.Base;
using MVVM1.ViewModels.ControlViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVM1.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private string _title = "MVVM1 | Вход";
        public string Title
        {
            get => _title;
            set => OnPropertyChanged(ref _title, value);
        }

        private readonly NavigationStore _navigationStore;
        public IControlViewModel CurrentViewModel => _navigationStore.CurrentViewModel;

        private WindowState _windowState;
        public WindowState WindowState
        {
            get => _windowState;
            set => OnPropertyChanged(ref _windowState, value);
        }

        public ICommand MinimazeCommand { get; }
        public ICommand MaximazeCommand { get; }
        public ICommand CloseCommand { get; }


        public MainWindowViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            MinimazeCommand = new RelayCommand(x => WindowState = WindowState.Minimized);
            MaximazeCommand = new RelayCommand(x => WindowState = WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal);
            CloseCommand = new RelayCommand(x => App.Current.Shutdown());

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            Title = CurrentViewModel.GetTitle() != "" ? "MVVM1 | " + CurrentViewModel.GetTitle() : "MVVM1";
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}