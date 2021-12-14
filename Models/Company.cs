using System;
using System.Collections.Generic;

#nullable disable

namespace MVVM1.Models
{
    public partial class Company
    {
        public Company()
        {
            Emps = new HashSet<Emp>();
        }

        public int Id { get; set; }
        public string Compname { get; set; }
        public int AdminId { get; set; }
        public int Code { get; set; }

        public virtual Admin Admin { get; set; }
        public virtual ICollection<Emp> Emps { get; set; }
    }
}
