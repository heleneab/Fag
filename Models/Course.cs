using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace test_4.Models
{

    public class Course
    {
        public Course()
        {
        }

        public Course(string user, string selectedCourses, string availableCourses)
        {
            SelectedCourses = selectedCourses;
            AvailableCourses = availableCourses;
            User = user;
        }

        public int Id { get; set; }
        
        public string SelectedCourses { get; set; }
        public string AvailableCourses { get; set; }

        public string User { get; set; }

    }
}