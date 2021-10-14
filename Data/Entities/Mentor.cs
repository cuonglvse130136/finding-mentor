using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("Mentor")]
    public class Mentor
    {
        [Key]
        
        public Guid Id { get; set; }
        

        public virtual ICollection<Course> Courses { get; set; }

  

        public int Rating { get; set; }


        public string MajorId { get; set; }
        [ForeignKey("MajorId")]
        public virtual Major Major { get; set; }


        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

    }
}
