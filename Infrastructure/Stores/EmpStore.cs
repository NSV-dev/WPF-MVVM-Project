using MVVM1.Models;
using MVVM1.Models.Context;
using System.Collections.Generic;
using System.Linq;

namespace MVVM1.Infrastructure.Stores
{
    public class EmpStore
    {
        private readonly List<Emp> _emps;

        public IEnumerable<Emp> Emps => _emps;

        public EmpStore()
        {
            _emps = new List<Emp>();
        }

        public void Load(TaskStore taskStore)
        {
            _emps.Clear();
            using (КурсоваяContext db = new())
            {
                _emps.AddRange(db.Emps);
                foreach (Emp emp in _emps)
                {
                    foreach (Task task in taskStore.Tasks.Where(t => t.EmpId == emp.Id))
                        emp.Tasks.Add(task);

                    emp.Company = db.Companies.Find(emp.CompanyId);
                    emp.Personality = db.Personalities.Find(emp.PersonalityId);
                    emp.Role = db.Roles.Find(emp.RoleId);
                }
            }
        }
    }
}
