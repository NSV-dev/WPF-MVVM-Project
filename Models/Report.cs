using System;
using System.Collections.Generic;

#nullable disable

namespace MVVM1.Models
{
    public partial class Report
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string Description { get; set; }

        public virtual Task Task { get; set; }
    }
}
