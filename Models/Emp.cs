using System;
using System.Collections.Generic;

#nullable disable

namespace MVVM1.Models
{
    public partial class Emp
    {
        public Emp()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int PersonalityId { get; set; }
        public int RoleId { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Personality Personality { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
