using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("AvailableMajor")]
    public class AvailableMajor
    {
        public string MajorId { get; set; }
        [Key, ForeignKey("MajorId")]
        public virtual Major Major { get; set; }

        public Guid MentorId { get; set; }
        [Key, ForeignKey("MentorId")]
        public virtual Mentor Mentor { get; set; }
    }
}
