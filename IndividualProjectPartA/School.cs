using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectPartA
{
    class School
    {
        public static List<Student> allStudents = new List<Student>();              //Contains all students
        public static List<Trainer> allTrainers = new List<Trainer>();              //Contains all Trainers
        public static List<Course> allCourses = new List<Course>();                 //Contains all Courses
        public static List<Assignment> allAssignment = new List<Assignment>();      //Contains all Assignments
        public static List<StudentsPerCourse> CourseAttendees = new List<StudentsPerCourse>();          //Contains all the StudentsPerCourse items
        public static List<TrainersPerCourse> CourseTrainers = new List<TrainersPerCourse>();           //Contains all the TrainersPerCourse items  
        public static List<AssignmentsPerCourse> CourseAssignments = new List<AssignmentsPerCourse>();  //Contains all the AssignmentsPerCourse items
        public static List<CoursesPerStudent> StudentCourses = new List<CoursesPerStudent>();           //Contains all the CoursesPerStudent items

        public static void AddStudentInList(Student student)
        {
            allStudents.Add(student);
        }
        public static void AddTrainerInList(Trainer trainer)
        {
            allTrainers.Add(trainer);
        }
        public static void AddCourseInList(Course course)
        {
            allCourses.Add(course);
        }
        public static void AddAssignmentInList(Assignment assignment)
        {
            allAssignment.Add(assignment);
        }
        public static void PrintStudents()
        {
            //check if it is an empty list and write msg
            if (allStudents.Count != 0)
            { 
                foreach (var item in allStudents)
                {
                    Console.OutputEncoding = Encoding.UTF8;
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("No students\n");
            }
        }
        public static void PrintTrainers()
        {
            if (allTrainers.Count != 0)
            {
                foreach (var item in allTrainers)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("No trainers\n");
            }
            
        }
        public static void PrintCourses()
        {
            if (allCourses.Count != 0)
            {
                foreach (var item in allCourses)
                {
                    Console.WriteLine(item);
                }

            }
            else
            {
                Console.WriteLine("No courses\n");
            }
           
        }
        public static void PrintAssignment()
        {
            if (allAssignment.Count != 0 )
            {
                foreach (var item in allAssignment)
                {
                    Console.WriteLine(item);
                }

            }
            else
            {
                Console.WriteLine("No Assignment\n");
            }
            
        }
        public static void PrintStudentsPerCourses()
        {
            if (CourseAttendees.Count != 0)
            {
                foreach (var item in CourseAttendees)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("No muches\n");
            }
            
        }
        public static void PrintTrainersPerCourses()
        {
            if (CourseTrainers.Count != 0)
            {
                foreach (var item in CourseTrainers)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("No muches\n");
            }
        }
        public static void PrintAssignmentsPerCourses()
        {
            if (CourseAssignments.Count != 0)
            {
                foreach (var item in CourseAssignments)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("No muches\n");
            }
        }
        public static void PrintAssignmentsPerStudent()
        {
            bool noAssignment = true;

            for (int i = 0; i < StudentCourses.Count; i++)
            {
                Console.Write(StudentCourses[i].student.firstName + " " + StudentCourses[i].student.lastName + ": ");

                //new list with assignments for each student
                List<Assignment> assignments = new List<Assignment>();

                for (int j = 0; j < StudentCourses[i].CourseStudent.Count; j++)
                {
                    //call the method from the class course that gives the assignments from the course
                    assignments.AddRange(StudentCourses[i].CourseStudent[j].getAssignments());
                    noAssignment = false;
                }
                if (assignments.Count == 0)
                {
                    Console.WriteLine(" No assignments");
                    continue;
                }
                //print list with the assignments
                Console.Write(assignments[0].title);
                for (int j = 1; j < assignments.Count; j++)
                {
                    Console.Write($", {assignments[j].title}");
                }
                Console.WriteLine();
            }
            if (noAssignment)
            {
                Console.WriteLine(" No assignments");
            }

        }
        public static void PrintStudentsWithMoreCourses()
        {
            bool noStudent = true;

            for (int i = 0; i < StudentCourses.Count; i++)
            {
                if (StudentCourses[i].CourseStudent.Count > 1)
                {
                    Console.WriteLine($"{StudentCourses[i].student.firstName} {StudentCourses[i].student.lastName}");
                    noStudent = false;
                }
            }
            if (noStudent)
            {
                Console.WriteLine("There are no students that belong to more than one courses");
            }

        }
        public static void MatchStudentsCourses()       //Matches the Course with all the attendees
        {
            //print the existing students and courses
            Console.Clear();
            Console.WriteLine("--------Students that already exists--------");
            PrintStudents();
            Console.WriteLine("\n--------Courses that already exists--------");
            PrintCourses();
            Console.WriteLine("\n\nWrite the titles of the courses and the fullname of students that they attend it");
            Console.WriteLine("Write finish when you are done");
            Console.WriteLine("For example: Chemistry : fullname , fullname...\n");
            bool firstTime = true;

            while (true)
            {
                if (!firstTime)
                {
                    //reminder for next user input
                    Console.WriteLine("\nWrite the next course and attendees or 'finish'");
                }

                string input = Console.ReadLine().Trim();

                if (input.ToLower().Trim() == "finish")
                {
                    break;
                }

                //Split and clean user input for further use
                string[] words = input.Split(':');
                string title = words[0].Trim();
                string names = words[1].Trim();
                bool courseExists = false;
                Course course = null;

                //Check if given Course already exists 
                for (int i = 0; i < School.allCourses.Count; i++)
                {
                    if (title == School.allCourses[i].title)
                    {
                       
                        course = School.allCourses[i];
                        courseExists = true;
                        break;
                    }
                }
                //If not ask user to insert it
                if (!courseExists)
                {
                    Console.WriteLine($"\nThe course {title} is not in list.Do you want to insert it? (Yes or No)");
                    if (Console.ReadLine().ToLower().Trim() == "yes")
                    {
                        Course.addCourses(true);
                        course = School.allCourses[allCourses.Count-1];
                    }
                    else
                    {
                        //if user doesn't want to insert the course, Continue with the next match
                        Console.WriteLine("\nWrite the title of the next course and the fullname of students that they attend it");
                        continue;
                    }

                }

                //Split the inserted names 
                string[] eachName = names.Split(',');
                List<Student> students = new List<Student>();
                bool matchExists = false;

                //Check if the Course has already attendees
                for (int i = 0; i < CourseAttendees.Count; i++)     
                {
                    if (title == CourseAttendees[i].course.title)       
                    {
                        //if it has, add the extra students to the attendees list
                        matchExists = true;
                        foreach (var item in eachName)
                        {
                            //Split the name of its Student and Clear
                            string[] student = item.Trim().Split();
                            string fName = student[0].ToUpper();
                            string lName = student[1].ToUpper();
                            bool studentAlreadyInList = false;
                            bool studentExists = false;

                            for (int k = 0; k < School.allStudents.Count; k++)
                            {
                                if (fName == School.allStudents[k].firstName && lName == School.allStudents[k].lastName)        //Check if the student exists in allStudents
                                {
                                    studentExists = true;
                                    break;
                                }
                            }
                            //If not ask user to insert it
                            if (!studentExists)
                            {
                                Console.WriteLine($"\nThe student {fName} {lName} is not in list.Do you want to insert it? (Yes or No)");
                                if (Console.ReadLine().ToLower() == "yes")
                                {
                                    Student.addStudent(true);
                                }
                            }

                            for (int x = 0; x < CourseAttendees[i].attendees.Count; x++)        
                            {
                                if (fName == CourseAttendees[i].attendees[x].firstName && lName == CourseAttendees[i].attendees[x].lastName)    //check if the student is already in the list of attendees
                                {
                                    studentAlreadyInList = true;
                                    break;
                                }
                            }
                            if (!studentAlreadyInList) //if not in list 
                            {
                                for (int j = 0; j < allStudents.Count; j++)
                                {
                                    if (fName == allStudents[j].firstName && lName == allStudents[j].lastName)
                                    {
                                        CourseAttendees[i].attendees.Add(allStudents[j]);   //Add the student in the list of attednees
                                        break;
                                    }
                                }

                            }


                        }

                        break;
                    }
                }
                if (!matchExists)       //if the course has not attendees
                {
                    foreach (var item in eachName)
                    {
                        //Split and clean user input for further use
                        string[] student = item.Trim().Split();
                        string fName = student[0].ToUpper();
                        string lName = student[1].ToUpper();
                        bool studentExists = false;

                        //Check if given Student already exists 
                        for (int i = 0; i < School.allStudents.Count; i++)
                        {
                            if (fName == School.allStudents[i].firstName && lName == School.allStudents[i].lastName)
                            {
                                students.Add(School.allStudents[i]);
                                studentExists = true;
                                break;
                            }
                        }
                        //If not ask user to insert it
                        if (!studentExists)
                        {
                            Console.WriteLine($"\nThe student {fName} {lName} is not in list.Do you want to insert it? (Yes or No)");
                            if (Console.ReadLine().ToLower() == "yes")
                            {
                                Student.addStudent(true);
                                students.Add(School.allStudents[allStudents.Count - 1]);
                            }
                        }
                    }
                    //Create the object StudentsPerCourse and add it to the list
                    School.CourseAttendees.Add(new StudentsPerCourse(course, students));
                }
                firstTime = false;
            }
            Console.Clear();

        }
        public static void MatchTrainersCourses()       //Matches the Course with all the trainers
        {
            //print the existing trainers and courses
            Console.Clear();
            Console.WriteLine("--------Trainers that already exists--------");
            PrintTrainers();
            Console.WriteLine("\n--------Courses that already exists--------");
            PrintCourses();
            Console.WriteLine("\n\nWrite the titles of the courses and the fullname of trainers that they teaching it");
            Console.WriteLine("Write finish when you are done");
            Console.WriteLine("For example: Chemistry : fullname , fullname...\n");
            bool firstTime = true;

            while (true)
            {
                if (!firstTime)
                {
                    //reminder for next user input
                    Console.WriteLine("\nWrite the next course and trainers or 'finish'");
                }
                string input = Console.ReadLine().Trim();

                if (input.ToLower() == "finish")
                {
                    break;
                }

                //Split and clean user input for further use
                string[] words = input.Split(':');
                string title = words[0].Trim();
                string names = words[1];
                bool courseExists = false;
                Course course = null;

                //Check if given Course already exists 
                for (int i = 0; i < allCourses.Count; i++)
                {
                    if (title == allCourses[i].title)
                    {
                       
                        course = allCourses[i];
                        courseExists = true;
                        break;
                    }
                }
                //If not ask user to insert it
                if (!courseExists)
                {
                    Console.WriteLine($"\nThe course {title} is not in list.Do you want to insert it? ('Yes' or 'No')");
                    if (Console.ReadLine().ToLower().Trim() == "yes")
                    {
                        Course.addCourses(true);
                        course = allCourses[allCourses.Count-1];
                    }
                    else
                    {
                        //if user doesn't want to insert the course, Continue with the next match
                        Console.WriteLine("\nWrite the title of the next course and the fullname of students that they attend it");
                        continue;
                    }
                }

                //Split the inserted names 
                string[] eachName = names.Split(',');
                List<Trainer> trainers = new List<Trainer>();
                bool matchExists = false;

                //Check if the Course has already trainers
                for (int i = 0; i < CourseTrainers.Count; i++)
                {
                    if (title == CourseTrainers[i].course.title)
                    {
                        //if it has, add the extra trainer to the trainers list
                        matchExists = true;
                        foreach (var item in eachName)
                        {
                            //Split the name of its Trainer and Clear
                            string[] trainer = item.Trim().Split();
                            string fName = trainer[0].ToUpper();
                            string lName = trainer[1].ToUpper();
                            bool trainerAlreadyInList = false;
                            bool trainerExists = false;

                            for (int k = 0; k < allTrainers.Count; k++)
                            {
                                if (fName == allTrainers[k].firstName && lName == allTrainers[k].lastName)        //Check if the trainer exists in allStudents
                                {
                                    trainerExists = true;
                                    break;
                                }
                            }
                            //If not ask user to insert it
                            if (!trainerExists)
                            {
                                Console.WriteLine($"\nThe trainer {fName} {lName} is not in list. Do you want to insert it? (Yes or No)");
                                if (Console.ReadLine().ToLower() == "yes")
                                {
                                    Trainer.addTrainers(true);
                                }
                            }

                            for (int x = 0; x < CourseTrainers[i].trainers.Count; x++)
                            {
                                if (fName == CourseTrainers[i].trainers[x].firstName && lName == CourseTrainers[i].trainers[x].lastName)    //check if the trainer is already in the list of trainers
                                {
                                    trainerAlreadyInList = true;
                                    break;
                                }
                            }
                            if (!trainerAlreadyInList) //if not in list 
                            {
                                for (int j = 0; j < allTrainers.Count; j++)
                                {
                                    if (fName == allTrainers[j].firstName && lName == allTrainers[j].lastName)
                                    {
                                        CourseTrainers[i].trainers.Add(allTrainers[j]);   //Add the trainer in the list of trainers
                                        break;
                                    }
                                }

                            }


                        }

                        break;
                    }
                }
                //if the course has not trainers
                if (!matchExists)
                {
                    foreach (var item in eachName)
                    {
                        //Split and clean user input for further use
                        string[] trainer = item.Trim().Split();
                        string fName = trainer[0].ToUpper();
                        string lName = trainer[1].ToUpper();
                        bool TrainerExists = false;

                        //Check if given Trainer already exists 
                        for (int i = 0; i < School.allTrainers.Count; i++)
                        {

                            if (fName == School.allTrainers[i].firstName && lName == School.allTrainers[i].lastName)
                            {
                                trainers.Add(School.allTrainers[i]);
                                TrainerExists = true;
                                break;
                            }
                        }
                        //If not ask user to insert it
                        if (!TrainerExists)
                        {
                            Console.WriteLine($"\nThe trainer {fName} {lName} is not in list.Do you want to insert it? (Yes or No)");
                            if (Console.ReadLine().ToLower() == "yes")
                            {
                                Trainer.addTrainers(true);
                                trainers.Add(School.allTrainers[allTrainers.Count - 1]);
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    //Create the object TrainersPerCourse and add it to the list
                    School.CourseTrainers.Add(new TrainersPerCourse(course, trainers));
                    
                }
                firstTime = false;
            }
            Console.Clear();
        }
        public static void MatchAssignmentsCourses()    //Matches the Course with all the Assignments
        {
            //print the existing assignments and courses
            Console.Clear();
            Console.WriteLine("--------Assignments that already exists--------");
            PrintAssignment();
            Console.WriteLine("\n--------Courses that already exists--------");
            PrintCourses();
            Console.WriteLine("\n\nWrite the titles of the courses and the assignments that contains");
            Console.WriteLine("Write finish when you are done");
            Console.WriteLine("For example: Chemistry : assignment , assignment...\n");
            bool firstTime = true;

            while (true)
            {
                if (!firstTime)
                {
                    //reminder for next user input
                    Console.WriteLine("\nWrite the next course and assignments or 'finish'");
                }
                string input = Console.ReadLine().Trim();

                if (input.ToLower().Trim() == "finish")
                {
                    break;
                }

                //Split and clean user input for further use
                string[] words = input.Split(':');
                string title = words[0].Trim();
                string assingments = words[1];
                bool courseExists = false;
                Course course = null;

                //Check if given Course already exists 
                for (int i = 0; i < allCourses.Count; i++)
                {
                    if (title == allCourses[i].title)
                    {
                        course = allCourses[i];
                        courseExists = true;
                        break;
                    }
                }
                //If not ask user to insert it
                if (!courseExists)
                {
                    Console.WriteLine($"\nThe course {title} is not in list.Do you want to insert it? ('Yes' or 'No')");
                    if (Console.ReadLine().ToLower().Trim() == "yes")
                    {
                        Course.addCourses(true);
                        course = School.allCourses[allCourses.Count - 1];
                    }
                    else
                    {
                        //if user doesn't want to insert the course, Continue with the next match
                        Console.WriteLine("\nWrite the title of the next course and the assignments that contains");
                        continue;
                    }
                }

               
                //Split the inserted assignments 
                string[] eachAssignment = assingments.Split(',');
                List<Assignment> assignments = new List<Assignment>();
                bool matchExists = false;
                //bool AssignmentExists = false;

                //Check if the Course has already attendees
                for (int i = 0; i < CourseAssignments.Count; i++)
                {
                    if (title == CourseAssignments[i].course.title)
                    {
                        //if it has, add the extra Assignment to the assignments list
                        matchExists = true;
                        foreach (var item in eachAssignment)
                        {
                            string assignment = item.Trim();
                            bool AssignmentAlreadyInList = false;
                            bool AssignmentExists = false;

                            for (int k = 0; k < allAssignment.Count; k++)
                            {
                                if (assignment == allAssignment[k].title)        //Check if the assignment exists in allAssignments
                                {
                                   AssignmentExists = true;
                                    break;
                                }
                            }
                            //If not ask user to insert it
                            if (!AssignmentExists)
                            {
                                Console.WriteLine($"\nThe assignment {assignment} is not in list. Do you want to insert it? (Yes or No)");
                                if (Console.ReadLine().ToLower() == "yes")
                                {
                                    Assignment.addAssignment(true);
                                }
                            }

                            for (int x = 0; x < CourseAssignments[i].assignments.Count; x++)
                            {
                                if (assignment == CourseAssignments[i].assignments[x].title)    //check if the assignment is already in the list of assignments
                                {
                                    AssignmentAlreadyInList = true;
                                    break;
                                }
                            }
                            if (!AssignmentAlreadyInList) //if not in list 
                            {
                                for (int j = 0; j < allAssignment.Count; j++)
                                {
                                    if (assignment == allAssignment[j].title)
                                    {
                                        CourseAssignments[i].assignments.Add(allAssignment[j]);   //Add the assignment in the list of assignments
                                        break;
                                    }
                                }

                            }


                        }

                        break;
                    }
                }
                //if the course has not assignments
                if (!matchExists)
                {
                    foreach (var item in eachAssignment)
                    {
                        //Clean user input for further use
                        string assignment = item.Trim();
                        bool AssignmentExists = false;

                        //Check if given Assignment already exists 
                        for (int i = 0; i < School.allAssignment.Count; i++)
                        {

                            if (assignment == School.allAssignment[i].title)
                            {
                                assignments.Add(School.allAssignment[i]);
                                AssignmentExists = true;
                                break;
                            }
                        }
                        //if not ask user to insert it
                        if (!AssignmentExists)
                        {
                            Console.WriteLine($"\nThe assignment {assignment} is not in list.Do you want to insert it? (Yes or No)");
                            if (Console.ReadLine().ToLower() == "yes")
                            {
                                Assignment.addAssignment(true);
                                assignments.Add(School.allAssignment[allAssignment.Count - 1]);
                            }
                        }
                    }
                    //Create the object AssignmentPerCourse and add it to the list
                    School.CourseAssignments.Add(new AssignmentsPerCourse(course, assignments));
                }
                firstTime = false;
            }
            Console.Clear();

        }
        public static void MatchCoursesStudent()        //Matches Student with all the Courses
        {
            Console.Clear();
            StudentCourses = new List<CoursesPerStudent>();

            for (int i = 0; i < allStudents.Count; i++)     //for each student
            {
                List<Course> CourseStudent = new List<Course>();

                for (int j = 0; j < CourseAttendees.Count; j++)     //for each item in matched Course with students l
                {
                    for (int k = 0; k < CourseAttendees[j].attendees.Count; k++)        //for each list of attendees it thiw course
                    {
                        //Check if studentn is in the list
                        if (allStudents[i].firstName == CourseAttendees[j].attendees[k].firstName && allStudents[i].lastName == CourseAttendees[j].attendees[k].lastName)   
                        {
                            CourseStudent.Add(CourseAttendees[j].course); //if yes add the course in the list of courses for this student
                            break;
                        }
                    }
                }
                //Create the object CoursesPerStudent and add it to list 
                StudentCourses.Add(new CoursesPerStudent(allStudents[i], CourseStudent));
            }
        }
        public static void SubmitThisWeek()             //Student that submit this week 
        {
            //Ask the user to give a date
            Console.WriteLine("Give me a date (dd/mm/yy)");
            string stringDate = Console.ReadLine().Trim();  //read and Clean the input
            var greg = new GregorianCalendar();         //call the calendar
            CultureInfo elGR = new CultureInfo("el-GR");
            DateTime date;

            bool correctParse = DateTime.TryParseExact(stringDate, "d/M/yyyy", elGR, DateTimeStyles.None, out date);
            
            //Check if the input is invalid and ask for insert it again
            while (!correctParse)
            {
                Console.WriteLine("Invalid input. Give me a date (d/mm/yy)");
                stringDate = Console.ReadLine().Trim();
                correctParse = DateTime.TryParseExact(stringDate, "d/M/yyyy", elGR, DateTimeStyles.None, out date);
            }


            int weekOfTheYear = greg.GetWeekOfYear(date,CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            int year = greg.GetYear(date);
            List<Assignment> assignmentsSameWeekSub = new List<Assignment>() { };

            
            for (int i = 0; i < allAssignment.Count; i++)       // for each assignment
            {
                //check if the submition date is in the same week aw the given one
                if (weekOfTheYear == greg.GetWeekOfYear(allAssignment[i].subDateTime,CalendarWeekRule.FirstDay, DayOfWeek.Monday) && year == greg.GetYear(allAssignment[i].subDateTime))
                {
                    //if yes add it to list
                    assignmentsSameWeekSub.Add(allAssignment[i]);
                }
            }
            List<Course> courses = new List<Course>();  //list with courses that have the assignments with the same sumbition date

            if (assignmentsSameWeekSub.Count != 0)      //if not list empty
            {
                for (int i = 0; i < assignmentsSameWeekSub.Count; i++)  //for each assignment in the list with the same submition date
                {
                    for (int j = 0; j < CourseAssignments.Count; j++)   //for all the matched course with the assignments list
                    {
                        for (int k = 0; k < CourseAssignments[j].assignments.Count; k++)    //for each assignment in this course
                        {
                            //Check if the assignment of this course is in the list with the assignments with the same submition date
                            if (assignmentsSameWeekSub[i].title == CourseAssignments[j].assignments[k].title)
                            {
                                courses.Add(CourseAssignments[j].course);   //add this course in list
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                //Inform the user that this week there is no assignment to be sumitted
                Console.WriteLine("No assignments this weeek");
                return;
            }

            List<Student> students = new List<Student>();   //Create the list with the students tha have to submite this week

            for (int i = 0; i < courses.Count; i++)     //for each course that has assignments to be submited this week
            {
                for (int j = 0; j < CourseAttendees.Count; j++) //for each match course with the students
                {
                    if (courses[i].title == CourseAttendees[j].course.title)    //Check if the Course that has assignments to be submited this week has attendees
                    {
                        for (int k = 0; k < CourseAttendees[j].attendees.Count; k++)    //for each attendee in this course 
                        {
                            if (students.Count == 0)                        //if is the first student in the the list with the students that have to submite this week add the student
                            {
                                students.Add(CourseAttendees[j].attendees[k]);
                            }
                            else
                            {                                               //if not the first student in new list 
                                bool studentAlreadyInList = false;
                                for (int x = 0; x < students.Count; x++)
                                {
                                                                            //check if the student is already in list
                                    if (students[x].firstName == CourseAttendees[j].attendees[k].firstName && students[x].lastName == CourseAttendees[j].attendees[k].lastName)
                                    {
                                        studentAlreadyInList = true;
                                        break;
                                    }
                                }
                                if (!studentAlreadyInList)                  //if student not in list add it
                                {
                                    students.Add(CourseAttendees[j].attendees[k]);
                                }
                            }
                        }
                    }
                }
            }
            //print the list with the students that have to submite this week
            Console.WriteLine("\nStudents that submit this week are:");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(students[i].firstName +" " + students[i].lastName);
            }
        }
    }

    
}
