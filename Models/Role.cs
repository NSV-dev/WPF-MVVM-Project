using System;
using System.Collections.Generic;

#nullable disable

namespace MVVM1.Models
{
    public partial class Role
    {
        public Role()
        {
            Admins = new HashSet<Admin>();
            Emps = new HashSet<Emp>();
        }

        public int Id { get; set; }
        public string Role1 { get; set; }

        public virtual ICollection<Admin> Admins { get; set; }
        public virtual ICollection<Emp> Emps { get; set; }
    }
}
