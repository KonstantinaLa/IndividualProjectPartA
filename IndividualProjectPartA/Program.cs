using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectPartA
{
    class Program
    {
        private static void syntheticData()
        {
            //Ask the user for synthetic data
            Console.WriteLine("Whould you like to use synthetic data? (Yes/No)");
            string input = Console.ReadLine().ToLower().Trim();

            while (input != "yes" && input != "no")
            {
                Console.WriteLine("Invalid input.Whould you like to use synthetic data ? (Yes / No) ");
                input = Console.ReadLine().ToLower().Trim();
            }
            if (input == "no")
            {
                firstMenu();
            }
            else
            {
                createData();
            }
            
        }
        private static void firstMenu()
        {
            Console.WriteLine("Add the student(s).");
            Student.addStudent(false);
            Console.WriteLine("Add the course(s).");
            Course.addCourses(false);
            School.MatchStudentsCourses();
            Console.WriteLine("Add the trainer(s).");
            Trainer.addTrainers(false);
            School.MatchTrainersCourses();
            Console.WriteLine("Add the assignment(s).");
            Assignment.addAssignment(false);
            School.MatchAssignmentsCourses();
        }
        private static bool MenuMatches()
        {
            Console.Clear();
            Console.WriteLine("\n--------Choose an option:--------");
            Console.WriteLine("1)Match course with attendees");
            Console.WriteLine("2)Match course with trainers");
            Console.WriteLine("3)Match course with assignments");
            Console.WriteLine("4)Return to first menu\n");
            string input = Console.ReadLine().Trim();
            switch (input)
            {
                case "1":
                    Console.Clear();
                    School.MatchStudentsCourses();
                    return true;
                case "2":
                    Console.Clear();
                    School.MatchTrainersCourses();
                    return true;
                case "3":
                    Console.Clear();
                    School.MatchAssignmentsCourses();
                    return true;
                default:
                    Console.Clear();
                    return false;
            }
           
        }
        static void Main(string[] args)
        {
            syntheticData();
            
            Console.Clear();

            bool showMenu = true;
            while (showMenu)
            {
                showMenu = Menu();
            }
        }
        private static void createData()
        {
            Student student1 = (new Student("KONSTANTINA", "LAKOUMENTA", "8/9/1998", 250));
            Student student2 = (new Student("GEORGE", "PAPADOPOULOS", "14/4/1995", 300));
            Student student3 = new Student("MARIA", "ANTONIOU", "3/11/1990", 400);
            School.allStudents.Add(student1);
            School.allStudents.Add(student2);
            School.allStudents.Add(student3);

            Course course1 =  new Course("C#", "Part time", "Online", "15/2/2021", "15/9/2021");
            Course course2 = new Course("Python", "Full time", "Physical presence", "1/3/2021", "1/6/2021");
            School.allCourses.Add(course1);
            School.allCourses.Add(course2);

            Trainer trainer1 = new Trainer("XRISTOS", "MICHALAKOPOULOS", "Programming");
            Trainer trainer2 = new Trainer("AGGELIKI", "ZAXAROPOULOU", "Programming");
            Trainer trainer3 = new Trainer("KATERINA", "ATHANASIOU", "Databases");
            School.allTrainers.Add(trainer1);
            School.allTrainers.Add(trainer2);
            School.allTrainers.Add(trainer3);

            Assignment ass1 = new Assignment("Project C#", "individual", "31/3/2021", "50", "100");
            Assignment ass2 = new Assignment("Project Python", "individual", "27/1/2021", "50", "100");
            Assignment ass3 = new Assignment("Database", "group", "15/5/2021", "30", "100");
            School.allAssignment.Add(ass1);
            School.allAssignment.Add(ass2);
            School.allAssignment.Add(ass3);

            //StudentsPerCourse
            StudentsPerCourse spc1 = new StudentsPerCourse(course1, new List<Student>() {student1 , student2});
            StudentsPerCourse spc2 = new StudentsPerCourse(course2, new List<Student>() {student2 , student3});
            School.CourseAttendees.Add(spc1);
            School.CourseAttendees.Add(spc2);

            //TrainersPerCourse
            TrainersPerCourse tpc1 = new TrainersPerCourse(course1, new List<Trainer>() { trainer1, trainer3 });
            TrainersPerCourse tpc2 = new TrainersPerCourse(course2, new List<Trainer>() { trainer2, trainer3 });
            School.CourseTrainers.Add(tpc1);
            School.CourseTrainers.Add(tpc2);


            //AssignmentsPerCourse
            AssignmentsPerCourse apc1 = new AssignmentsPerCourse(course1, new List<Assignment>() { ass1, ass3 });
            AssignmentsPerCourse apc2 = new AssignmentsPerCourse(course2, new List<Assignment>() { ass2, ass3 });
            School.CourseAssignments.Add(apc1);
            School.CourseAssignments.Add(apc2);

            //CoursesPerStudent
            CoursesPerStudent cps1 = new CoursesPerStudent(student1, new List<Course>() { course1 });
            CoursesPerStudent cps2 = new CoursesPerStudent(student2, new List<Course>() { course1, course2 });
            CoursesPerStudent cps3 = new CoursesPerStudent(student3, new List<Course>() { course2 });
            School.StudentCourses.Add(cps1);
            School.StudentCourses.Add(cps2);
            School.StudentCourses.Add(cps3);

        }
        private static bool Menu()
        {
            
            Console.WriteLine("\n--------Choose an option:--------\n");
            Console.WriteLine("1)Add extra students");
            Console.WriteLine("2)Print a list of student\n");
            Console.WriteLine("3)Add extra courses");
            Console.WriteLine("4)Print a list of courses.\n");
            Console.WriteLine("5)Add extra trainers");
            Console.WriteLine("6)Print a list of trainers\n");
            Console.WriteLine("7)Add extra assignments");
            Console.WriteLine("8)Print a list of assignments \n");
            Console.WriteLine("9)Print all the student per courses.");
            Console.WriteLine("10)Print all the trainers per course.");
            Console.WriteLine("11)Print all the assignements per course.");
            Console.WriteLine("12)Print all the assignments per student.");
            Console.WriteLine("13)Print a list of students that belong to more than one courses");
            Console.WriteLine("14)Print a list of students who need to submit one or more assignments on the same calemndar week.");
            Console.WriteLine("\n15) Make new matches");
            Console.WriteLine("16)Exit\n");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();
                    Student.addStudent(false);
                    return true;
                case "2":
                    Console.Clear();
                    School.PrintStudents();
                    return true;
                case "3":
                    Console.Clear();
                    Course.addCourses(false);
                    School.MatchStudentsCourses();
                    return true;
                case "4":
                    Console.Clear();
                    School.PrintCourses();
                    return true;
                case "5":
                    Console.Clear();
                    Trainer.addTrainers(false);
                    School.MatchTrainersCourses();
                    return true;
                case "6":
                    Console.Clear();
                    School.PrintTrainers();
                    return true;
                case "7":
                    Console.Clear();
                    Assignment.addAssignment(false);
                    School.MatchAssignmentsCourses();
                    return true;
                case "8":
                    Console.Clear();
                    School.PrintAssignment();
                    return true;
                case "9":
                    Console.Clear();
                    School.PrintStudentsPerCourses();
                    return true;
                case "10":
                    Console.Clear();
                    School.PrintTrainersPerCourses();
                    return true;
                case "11":
                    Console.Clear();
                    School.PrintAssignmentsPerCourses();
                    return true;
                case "12":
                    Console.Clear();
                    School.MatchCoursesStudent();
                    School.PrintAssignmentsPerStudent();
                    return true;
                case "13":
                    School.MatchCoursesStudent();
                    School.PrintStudentsWithMoreCourses();
                    return true;
                case "14":
                    Console.Clear();
                    School.SubmitThisWeek();
                    return true;
                case "15":
                    Console.Clear();
                    bool showMenu = true;
                    while (showMenu)
                    {
                        showMenu = MenuMatches();
                    }
                    return true;
                case "16":
                    return false;
                default:
                    return true;

            }

        }
    }
}
