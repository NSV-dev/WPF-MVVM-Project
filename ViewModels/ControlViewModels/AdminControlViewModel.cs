using MVVM1.Infrastructure.Stores;
using MVVM1.Models;
using MVVM1.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVM1.ViewModels.ControlViewModels
{
    public class AdminControlViewModel : BaseViewModel, IControlViewModel
    {
        private readonly ObservableCollection<Emp> _emps;
        public IEnumerable<Emp> Emps => _emps;

        public AdminControlViewModel(Admin admin, EmpStore empStore)
        {
            _emps = new ObservableCollection<Emp>();

            foreach (Emp emp in empStore.Emps)
                if (emp.Company.AdminId == admin.Id)
                    _emps.Add(emp);
        }

        public string GetTitle() => "";
    }
}
