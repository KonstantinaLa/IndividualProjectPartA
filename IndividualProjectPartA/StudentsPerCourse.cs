using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectPartA
{
    //Class that matches a Course with a list of Students
    class StudentsPerCourse
    {
        public List<Student> attendees { get; }
        public Course course {get;}

        public StudentsPerCourse(Course course, List<Student> attendees)
        {
            this.course = course;
            this.attendees = attendees;
        }
        public override string ToString()
        {
            if (attendees.Count == 0)
            {
                return $"{course.title}: No attendees";
            }

            string Names = attendees[0].firstName + " " + attendees[0].lastName;

            for (int i = 1; i < attendees.Count; i++)
            {
                Names += ", " + attendees[i].firstName + " " + attendees[i].lastName;
            }
            
            return $"{course.title}: {Names}";
        }
        
    }
}
