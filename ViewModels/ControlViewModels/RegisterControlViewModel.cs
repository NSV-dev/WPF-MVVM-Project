using MVVM1.Infrastructure.Commands;
using MVVM1.Infrastructure.Commands.Base;
using MVVM1.Infrastructure.Stores;
using MVVM1.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM1.ViewModels.ControlViewModels
{
    public class RegisterControlViewModel : BaseViewModel, IControlViewModel
    {
        public ICommand ToLogCommand { get; }

        public RegisterControlViewModel(NavigationStore navigationStore, EmpStore empStore, TaskStore taskStore)
        {
            ToLogCommand = new RelayCommand(x => navigationStore.CurrentViewModel = new LogInControlViewModel(navigationStore, empStore, taskStore));
        }

        public string GetTitle() => "Регистрация";
    }
}
