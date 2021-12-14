using System;
using System.Collections.Generic;

#nullable disable

namespace MVVM1.Models
{
    public partial class Admin
    {
        public Admin()
        {
            Companies = new HashSet<Company>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int PersonalityId { get; set; }

        public virtual Personality Personality { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
    }
}
