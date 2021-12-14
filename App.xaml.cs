using MVVM1.Infrastructure.Stores;
using MVVM1.ViewModels;
using MVVM1.ViewModels.Base;
using MVVM1.ViewModels.ControlViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private readonly EmpStore _empStore;
        private readonly TaskStore _taskStore;

        public App()
        {
            _navigationStore = new();
            _taskStore = new();
            _empStore = new();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _taskStore.Load();
            _empStore.Load(_taskStore);

            _navigationStore.CurrentViewModel = new LogInControlViewModel(_navigationStore, _empStore, _taskStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
