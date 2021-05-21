using Online_Academy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Academy.ViewModel
{
    public class CourseViewModel
    {
        public Course course { get; set; }
        public view_Teachers teacher { get; set; }
    }
}