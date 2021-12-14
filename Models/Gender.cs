using System;
using System.Collections.Generic;

#nullable disable

namespace MVVM1.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Personalities = new HashSet<Personality>();
        }

        public int Id { get; set; }
        public string Gender1 { get; set; }

        public virtual ICollection<Personality> Personalities { get; set; }
    }
}
