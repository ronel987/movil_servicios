using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movil.Models
{
    public class CategoryCourse
    {
        public Guid IdCategory { get; set; }
        public Category Category { get; set; }

        public Guid IdCourse { get; set; }
        public Course Course { get; set; }
    }
}
