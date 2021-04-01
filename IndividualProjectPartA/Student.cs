using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectPartA
{
    class Student
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        private float tuitionFees { get; set; }

        private DateTime dateBirth; //variable
        public DateTime dateOfBirth  //property
        {
            get => dateBirth;
            set
            {
                dateBirth = value;
            }
        }
        public Student(string firstName, string lastName, string stringDate, float tuitionFees)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.tuitionFees = tuitionFees;

            //creates greek date culture
            CultureInfo elGR = new CultureInfo("el-GR");
            bool correctParse = DateTime.TryParseExact(stringDate, "d/M/yyyy", elGR, DateTimeStyles.None, out dateBirth);

            //check if date is in correct form
            while (!correctParse)
            {
                Console.WriteLine("Invalid input. Give me the date of birth again (dd/mm/yy)");
                stringDate = Console.ReadLine().Trim();
                correctParse = DateTime.TryParseExact(stringDate, "d/M/yyyy", elGR, DateTimeStyles.None, out dateBirth);
            }
        }
        

        public override string ToString()
        {
            return $"{firstName} {lastName} {dateBirth.ToString("d / M / yyyy")} {tuitionFees}€";
        }
        public static void addStudent(bool onlyOneEntry)
        {
            string message;
            if (onlyOneEntry)
            {
                //executes if user chose to add extra student (in School.MatchStudentsCourses())
                message = "Write the fullname of the student: "; 
            }
            else
            {
                Console.Clear();
                message = "Write the fullname of the student or 'Finish': ";
            }

            Console.Write(message);
            string fullName = Console.ReadLine();
            
            while (fullName.ToUpper().Trim() != "FINISH")
            {
                //get student info
                string[] fullnameArray = fullName.Trim().Split(' ');
                string name = fullnameArray[0].ToUpper();
                string lastName = fullnameArray[1].ToUpper();

                Console.Write("Give me the date Of Birth(dd/mm/yy): ");
                string dateOfBirth = Console.ReadLine();
                dateOfBirth = dateOfBirth.Trim();

                Console.Write("Give me the tuition Fees: ");
                float tuitionFees = 0;
                bool notNumber = true;

                //check if tuition fees are valid input
                while (notNumber)
                {
                    try
                    {
                        tuitionFees = float.Parse(Console.ReadLine().Trim());
                        notNumber = false;
                    }
                    catch (Exception)
                    {
                        Console.Write("Invalid input.Give me the tuition Fees: ");
                    }
                }

                //Creates Student object and adds it to list
                School.AddStudentInList(new Student(name, lastName, dateOfBirth, tuitionFees));

                if (onlyOneEntry)
                {
                    //Return to Student-Course matching
                    break;
                }
                else
                {
                    //Continue with next Student input or 'finish'
                    Console.Write("Write the fullname of the student or 'finish': ");
                    fullName = Console.ReadLine();
                    
                } 
            }
            if (!onlyOneEntry)
            {
                Console.Clear();
            }
            
            

        }

    }
}
