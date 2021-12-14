using MVVM1.Infrastructure.Commands.Base;
using MVVM1.Infrastructure.Stores;
using MVVM1.Models;
using MVVM1.Models.Context;
using MVVM1.ViewModels.Base;
using System.Windows.Input;

namespace MVVM1.ViewModels.ControlViewModels
{
    public class LogInControlViewModel : BaseViewModel, IControlViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly EmpStore _empStore;
        private readonly TaskStore _taskStore;

        private int _errorOpacity;
        public int ErrorOpacity
        {
            get => _errorOpacity;
            set => OnPropertyChanged(ref _errorOpacity, value);
        }

        private string _login;
        public string Login { get => _login; set { OnPropertyChanged(ref _login, value); ErrorOpacity = 0; } }

        private string _password;
        public string Password { get => _password; set { OnPropertyChanged(ref _password, value); ErrorOpacity = 0; } }

        public ICommand ToRegCommand { get; }

        public ICommand LogInCommand { get; }

        private void OnLogInCommandExecute(object p)
        {
            foreach (Emp emp in _empStore.Emps)
                if (_login == emp.Login && _password == emp.Password)
                    _navigationStore.CurrentViewModel = new EmpControlViewModel(emp, _taskStore, _navigationStore, _empStore);
            using (КурсоваяContext db = new())
            {
                foreach (Admin admin in db.Admins)
                    if (_login == admin.Login && _password == admin.Password)
                        _navigationStore.CurrentViewModel = new AdminControlViewModel(admin, _empStore);
            }
            ErrorOpacity = 1;
        }

        public LogInControlViewModel(NavigationStore navigationStore, EmpStore empStore, TaskStore taskStore)
        {
            _navigationStore = navigationStore;
            _empStore = empStore;
            _taskStore = taskStore;

            ToRegCommand = new RelayCommand(x => navigationStore.CurrentViewModel = new RegisterControlViewModel(navigationStore, empStore, taskStore));
            LogInCommand = new RelayCommand(OnLogInCommandExecute, x => !string.IsNullOrEmpty(_login) && !string.IsNullOrEmpty(_password));
        }

        public string GetTitle() => "Вход";
    }
}
