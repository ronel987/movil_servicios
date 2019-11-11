using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movil.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; } //= Guid.NewGuid();

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public bool Status { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
