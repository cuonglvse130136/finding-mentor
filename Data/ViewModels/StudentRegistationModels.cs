using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ViewModels
{
    public class StudentRegistationModels
    {
        public string Id { get; set; }
        public string Fullname { get; set; }
        public string MajorId { get; set; }
        public DateTime StartDate { get; set; }

        public string AvatarUrl { get; set; }
    }

    public class StudentRegistationModel
    {
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public DateTime StartDate { get; set; }
    }
}
