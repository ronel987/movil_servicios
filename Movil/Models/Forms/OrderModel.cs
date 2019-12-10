using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movil.Models.Forms
{
    public class OrderModel
    {
        public string IdTeacher { get; set; }

        public DateTime StartDate { get; set; }

        public int time { get; set; }

        public string[] IdCourseContent { get; set; }
    }
}
