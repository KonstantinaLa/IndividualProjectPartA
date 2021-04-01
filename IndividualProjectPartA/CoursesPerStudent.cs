using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectPartA
{
    //Class that matches a Student with a list of Courses
    class CoursesPerStudent
    {
        public Student student;
        public List<Course> CourseStudent = new List<Course>();

        public CoursesPerStudent( Student student , List<Course> CourseStudent )
        {
            this.student = student;
            this.CourseStudent = CourseStudent;
        }
    }
}
