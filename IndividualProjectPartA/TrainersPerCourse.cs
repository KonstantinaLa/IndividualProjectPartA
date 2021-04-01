using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectPartA
{
    //Class that matches a Course with a list of Trainers
    class TrainersPerCourse
    {
        public List<Trainer> trainers = new List<Trainer>();
        public Course course;

        public TrainersPerCourse(Course course, List<Trainer> trainersInCourse)
        {
            this.course = course;
            this.trainers = trainersInCourse;
        }
        public override string ToString()
        {
            if (trainers.Count == 0)
            {
                return $"{course.title}: No attendees";
            }
            string Names = trainers[0].firstName + " " + trainers[0].lastName;

            for (int i = 1; i < trainers.Count; i++)
            {
                Names += ", " + trainers[i].firstName + " " + trainers[i].lastName;
            }

            return $"{course.title}: {Names}";
        }
    }
}
