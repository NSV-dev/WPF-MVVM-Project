using System;
using System.Collections.Generic;

#nullable disable

namespace MVVM1.Models
{
    public partial class Task
    {
        public Task()
        {
            Reports = new HashSet<Report>();
        }

        public int Id { get; set; }
        public string Taskname { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int EmpId { get; set; }
        public bool? Expired { get; set; }
        public bool? Verification { get; set; }

        public virtual Emp Emp { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
