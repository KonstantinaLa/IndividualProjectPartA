using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectPartA
{
    class Course
    {
        public string title { get; set; }
        private string stream { get; set; }
        private string type { get; set; }

        private DateTime start_date; //variable
        private DateTime end_date;  //variable

        private DateTime start_date_time //property
        {
            get => start_date;
            set
            {
                start_date = value;
            }
        }
        private DateTime end_date_time //property
        {
            get => end_date;
            set
            {
                end_date = value;
            }
        }

        public Course(string title, string stream, string type, string stringStart_date, string stringEnd_date)
        {
            this.title = title;
            this.stream = stream;
            this.type = type;

            //creates greek date culture
            CultureInfo elGR = new CultureInfo("el-GR");

            bool correctParse = DateTime.TryParseExact(stringStart_date, "d/M/yyyy", elGR, DateTimeStyles.None, out start_date);

            while (!correctParse)
            {
                //check if date is in correct form
                Console.WriteLine("Invalid input. Give me the start date of the course (dd/mm/yy)");
                stringStart_date = Console.ReadLine().Trim();
                correctParse = DateTime.TryParseExact(stringStart_date, "d/M/yyyy", elGR, DateTimeStyles.None, out start_date);
            }
            bool correctParse2 = DateTime.TryParseExact(stringEnd_date, "d/M/yyyy", elGR, DateTimeStyles.None, out end_date);

            while (!correctParse2)
            {
                Console.WriteLine("Invalid input. Give me the end date of the course (dd/mm/yy)");
                stringEnd_date = Console.ReadLine().Trim();
                correctParse2 = DateTime.TryParseExact(stringEnd_date, "d/M/yyyy", elGR, DateTimeStyles.None, out end_date);
            }

        }

        public override string ToString()
        {
            return $"{title} {stream} {type} starting date: {start_date.ToString("d / M / yyyy")} end date: {end_date.ToString("d / M / yyyy")}";
        }

        public static void addCourses(bool onlyOneEntry)
        {
            string message;
            if (onlyOneEntry)
            {
                //executes if user chose to add extra course (in School.MatchStudentsCourses() or School.MatchAssignmentsCourses())
                message = "Write the title of the Course: ";
            }
            else
            {
                Console.Clear();
                message = "Write the title of the Course or 'Finish': ";
            }
           
            Console.Write(message);
            string course = Console.ReadLine();

            while (course.ToUpper().Trim() != "FINISH")
            {
                course = course.Trim();

                //get course info
                Console.Write("Write the stream: ");
                string stream = Console.ReadLine();
                stream = stream.Trim();
                Console.Write("Write the type of course: ");
                string type = Console.ReadLine();
                type = type.Trim();
                Console.Write("Write the start date: ");
                string start_date = Console.ReadLine();
                start_date = start_date.Trim();
                Console.Write("Write the end date: ");
                string end_date = Console.ReadLine();
                end_date = end_date.Trim();

                //Creates Course object and adds it to list
                School.AddCourseInList(new Course(course, stream, type, start_date, end_date));
                
                if (onlyOneEntry)
                {
                    //Return to Student-Course matching or Assignments-Course matching
                    break;
                }
                else
                {
                    //Continue with next Course input or 'finish'
                    Console.Write("Write the title of the Course or 'finish': ");
                    course = Console.ReadLine();
                    
                }
            }
            if (!onlyOneEntry)
            {
                Console.Clear();
            }


        }

        public List<Assignment> getAssignments()
        {//dinei ta assignment toy course 
            List<Assignment> assignments = new List<Assignment>();

            for (int i = 0; i < School.CourseAssignments.Count; i++)
            {
                if (School.CourseAssignments[i].course.title == this.title)
                {
                    for (int j = 0; j < School.CourseAssignments[i].assignments.Count; j++)
                    {
                        assignments.Add(School.CourseAssignments[i].assignments[j]);
                    }
                }
            }
            return assignments;
        }
    }
}
