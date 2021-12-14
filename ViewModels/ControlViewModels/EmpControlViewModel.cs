using FontAwesome.WPF;
using MVVM1.Infrastructure.Commands.Base;
using MVVM1.Infrastructure.Stores;
using MVVM1.Models;
using MVVM1.ViewModels.Base;
using MVVM1.ViewModels.ControlViewModels.EmpControlPages;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace MVVM1.ViewModels.ControlViewModels
{
    public class EmpControlViewModel : BaseViewModel, IControlViewModel
    {
        private readonly TaskStore _taskStore;
        private readonly NavigationStore _navigationStore;
        private readonly EmpStore _empStore;

        private BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set => OnPropertyChanged(ref _currentViewModel, value);
        }

        private CollectionViewSource MenuItemsCollection;
        public ICollectionView MenuItems => MenuItemsCollection.View;

        public ICommand ChangeViewCommand { get; set; }
        private void OnChangeViewCommandExecute(object parameter)
        {
            switch(parameter)
            {
                case "Главная":
                    CurrentViewModel = new HomeControlViewModel();
                    break;
                case "Задачи":
                    CurrentViewModel = new TasksControlViewModel();
                    break;
                case "Аккаунт":
                    CurrentViewModel = new AccountControlViewModel();
                    break;
                case "Выход":
                    _navigationStore.CurrentViewModel = new LogInControlViewModel(_navigationStore, _empStore, _taskStore);
                    break;
                default:
                    CurrentViewModel = new HomeControlViewModel();
                    break;
            }
        }

        public EmpControlViewModel(Emp emp, TaskStore taskStore, NavigationStore navigationStore, EmpStore empStore)
        {
            _taskStore = taskStore;
            _navigationStore = navigationStore;
            _empStore = empStore;

            ObservableCollection<MenuItem> menuItems = new()
            {
                new MenuItem { MenuName = "Главная", MenuIcon = FontAwesomeIcon.Home },
                new MenuItem { MenuName = "Задачи", MenuIcon = FontAwesomeIcon.Tasks },
                new MenuItem { MenuName = "Аккаунт", MenuIcon = FontAwesomeIcon.User },
                new MenuItem { MenuName = "Выход", MenuIcon = FontAwesomeIcon.SignOut }
            };
            MenuItemsCollection = new CollectionViewSource { Source = menuItems };

            ChangeViewCommand = new RelayCommand(p=>OnChangeViewCommandExecute(p));

            OnChangeViewCommandExecute("");
        }

        public string GetTitle() => "";
    }
}
