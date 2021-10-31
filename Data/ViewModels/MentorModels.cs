using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ViewModels
{
    public class MentorAddModel
    {
        public string Fullname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public int Status { get; set; }
        public string MajorId { get; set; }
    }

    public class MentorViewModel: UserViewModels
    {
        public List<MentorDataModel> Data { get; set; } = new List<MentorDataModel>();
    }

    public class MentorDataModel
    {
        public int Rating { get; set; }
        public bool IsGraduted { get; set; }
        public string About { get; set; }
        public string Company { get; set; }
        public string AvatarUrl { get; set; }

        public List<SubjectViewModel1> SubjectViewModels { get; set; } = new List<SubjectViewModel1>();

        public MajorViewModel1 MajorViewModel { get; set; }
    }
    
    public class MentorUpdateModel
    {
        public string Fullname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public int Status { get; set; }
        public string MajorId { get; set; }
    }

    public class MentorAddRatingModel
    {
        public int Rating { get; set; }
    }
}
