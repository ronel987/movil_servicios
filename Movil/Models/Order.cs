using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Movil.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime CreateAt { get; set; }

        public int time { get; set; }

        public string status { get; set; }

        public ICollection<CourseContentOrder> CourseContentOrders { get; set; }

        public string StudentId { get; set; }

        public string TeacherId { get; set; }

        [ForeignKey("StudentId")]
        public virtual AppUser Student { get; set; }

        [ForeignKey("TeacherId")]
        public virtual AppUser Teacher { get; set; }

       
    }
}
