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
        public bool IsGraduted { get; set; } = false;
        public string About { get; set; }
        public string Company { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual ICollection<SubjectMentor> SubjectMentors { get; set; } = new HashSet<SubjectMentor>();
        public virtual ICollection<AvailableMajor> AvailableMajors { get; set; } = new HashSet<AvailableMajor>();

    }
}
