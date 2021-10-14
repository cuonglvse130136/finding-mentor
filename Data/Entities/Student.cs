using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("Student")]
    public class Student
    {
        [Key]
        
        public Guid Id { get; set; }
       

        public virtual ICollection<StudentRegistration> StudentRegistrations { get; set; }


        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

    }
}
