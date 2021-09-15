using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }

        public Guid SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }

        public DateTime StartDate { get; set; }
        public double Price { get; set; }

        public string MentorId { get; set; }
        [ForeignKey("MentorId")]
        public virtual User Mentor { get; set; }
    }
}
