using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    public class AvailableMajor
    {
        public string MentorId { get; set; }
        [Key, ForeignKey("MentorId")]
        public virtual User Mentor { get; set; }

        public Guid MajorId { get; set; }
        [Key, ForeignKey("MajorId")]
        public virtual Major Major { get; set; }
    }
}
