using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ViewModels
{
    public class MentorAddModel
    {

        
        public string UserId { get; set; }
        public bool IsGraduted { get; set; }
        public string About { get; set; }
        public string Company { get; set; }
        public string AvatarUrl { get; set; }
        public List<string> SubjectIds { get; set; }
        public string[] MajorIds { get; set; }


    }

    public class MentorViewModel: UserViewModels
    {
        public MentorDataModel Mentor { get; set; } = new MentorDataModel();
    }

    public class MentorDataModel
    {
        public int Rating { get; set; }
        public bool IsGraduted { get; set; }
        public string About { get; set; }
        public string Company { get; set; }

        public List<SubjectViewModel1> Subjects { get; set; } = new List<SubjectViewModel1>();

        public List<MajorViewModel1> Majors { get; set; } = new List<MajorViewModel1>();
    }
    
    public class MentorUpdateModel
    {
        public string Fullname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public int Status { get; set; }
        public string MajorId { get; set; }
        public string PhoneNumber { get; set; }

    }

    public class MentorUpdateModel1
    {
        public string Fullname { get; set; }
        public string AvatarUrl { get; set; }
        public bool IsGraduted { get; set; }
        public string About { get; set; }
        public string Company { get; set; }

        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string[] MajorIds { get; set; }
        public string[] SubjectIds { get; set;}
    }

    public class MentorAddRatingModel
    {
        public int Rating { get; set; }
    }
}
