using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movil.Models
{
    public class Course
    {
        [Key]
        public Guid Id { get; set; }// = Guid.NewGuid();

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public double Point { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public bool Status { get; set; }

        public AppUser User { get; set; }

        public ICollection<CategoryCourse> CategoryCourses { get; set; } = new List<CategoryCourse>();
    }
}
