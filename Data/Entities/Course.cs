using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("Course")]
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        
       
        public int Rating { get; set; }
        public DateTime StartDate { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        



        public Guid MentorId { get; set; }
        [ForeignKey("MentorId")]
        public virtual Mentor Mentor { get; set; }
        public string SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }
        public string MajorId { get; set; }
        [ForeignKey("MajorId")]
        public virtual Major Major { get; set; }



        public virtual ICollection<StudentRegistration> StudentRegistrations { get; set; }

        public virtual ICollection<Section> Sections { get; set; }



    }
}
