using System;
using System.Collections.Generic;

#nullable disable

namespace MVVM1.Models
{
    public partial class Personality
    {
        public Personality()
        {
            Admins = new HashSet<Admin>();
            Emps = new HashSet<Emp>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public int GenderId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Dateofbirth { get; set; }
        public string Address { get; set; }
        public string Info { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual ICollection<Admin> Admins { get; set; }
        public virtual ICollection<Emp> Emps { get; set; }
    }
}
