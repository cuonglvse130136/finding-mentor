using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    public class StudentRegistration : BaseEntity
    {
        public string StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual User Student { get; set; }

        public Guid CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
    }
}
