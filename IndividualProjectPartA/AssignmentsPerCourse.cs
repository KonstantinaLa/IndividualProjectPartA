using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectPartA
{
    //Class that matches a Course with a list of Assignments
    class AssignmentsPerCourse
    {
        public List<Assignment> assignments = new List<Assignment>();
        public Course course;

        public AssignmentsPerCourse(Course course, List<Assignment> assignments)
        {
            this.course = course;
            this.assignments = assignments;
        }
        public override string ToString()
        {
            if (assignments.Count == 0)
            {
                return $"{course.title}: No attendees";
            }
            string answer = assignments[0].title;

            for (int i = 1; i < assignments.Count; i++)
            {
                answer += ", " + assignments[i].title;
            }

            return $"{course.title}: {answer}";
        }

    }

}
