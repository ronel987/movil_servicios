using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movil.Models.Forms
{
    public class CourseModel
    {

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public Guid Id_Category { get; set; }

        public bool Status { get; set; }
    }

    public class CourseContentModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Duration { get; set; }

        public string Description { get; set; }

        public int Cost { get; set; }

        public bool Status { get; set; }

        public Guid Id_Course { get; set; }
    }
}
