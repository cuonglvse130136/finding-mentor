using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    public class Question : BaseEntity
    {
        public string Content { get; set; }

        public string StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual User Student { get; set; }

        public Guid SectionId { get; set; }
        [ForeignKey("SectionId")]
        public virtual Section Section { get; set; }
    }
}
