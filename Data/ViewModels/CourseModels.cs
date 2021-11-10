using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ViewModels
{
    public class CourseAddModels
    {
     
        public string SubjectId { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
       // public Guid MentorId { get; set; }
        public DateTime StartDate { get; set; } 
    }

    public class CourseUpdateModels
    {
        public string SubjectId { get; set; }
        public Guid MentorId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public string Duration { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
    public class CourseViewModel
    {
        public Guid Id { get; set; }
        public Guid MentorId { get; set; }
        public string MentorName { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string SubjectId { get; set; }

        public string MajorId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;

       
    }
}
