using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("StudentRegistration")]
    public class StudentRegistration
    {

        public Guid StudentId { get; set; }
        [Key,ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        public Guid CourseId { get; set; }
        [Key,ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
        public DateTime StartDate { get; set; }

        public bool IsEnroll { get; set; }

    }
}
