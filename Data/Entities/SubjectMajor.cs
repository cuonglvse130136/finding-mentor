using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("SubjectMajor")]
    public class SubjectMajor
    {
        [Column(Order = 0)]
        public string SubjectId { get; set; }
        [Key, ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }

        [Column(Order = 1)]
        public string MajorId { get; set; }
        [Key, ForeignKey("MajorId")]
        public virtual Major Major { get; set; }
    }
}
