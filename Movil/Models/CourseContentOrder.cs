using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movil.Models
{
    public class CourseContentOrder
    {
        [Key]
        public Guid Id { get; set; }

        public Order Order { get; set; }

        public CourseContent CourseContent { get; set; }
    }
}
