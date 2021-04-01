using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectPartA
{
    class Assignment
    {
        public string title { get; set; }
        private string description { get; set; }
        private string oralMark { get; set; }
        private string totalMark { get; set; }

        private DateTime subDate;//variable

        public DateTime subDateTime  //property
        {
            get => subDate;
            set
            {
                subDate = value;
            }
        }
        public Assignment(string title, string description, string stringDate, string oralMark, string totalMark)
        {
            this.title = title;
            this.description = description;
            this.oralMark = oralMark;
            this.totalMark = totalMark;

            //creates greek date culture
            CultureInfo elGR = new CultureInfo("el-GR");
            bool correctParse = DateTime.TryParseExact(stringDate, "d/M/yyyy", elGR, DateTimeStyles.None, out subDate);

            //check if date is in correct form
            while (!correctParse)
            {
                Console.WriteLine("Invalid input. Give me a submission date (dd/mm/yy)");
                stringDate = Console.ReadLine().Trim();
                correctParse = DateTime.TryParseExact(stringDate, "d/M/yyyy", elGR, DateTimeStyles.None, out subDate);
            }
        }

        public static void addAssignment(bool onlyOneEntry)
        {
            string message;
            if (onlyOneEntry)
            {
                //executes if user chose to add extra student (in School.MatchhAssignmentsCourses())
                message = "Write the title of the Assignment: ";
            }
            else
            {
                Console.Clear();
                message = "Write the title of the Assignment or 'finish': ";
            }

            Console.Write(message);
            string title = Console.ReadLine();

            while (title.ToUpper().Trim() != "FINISH")
            {
                title = title.Trim();

                //get assignment info
                Console.Write("Write the description of the Assignment: ");
                string description = Console.ReadLine().Trim();
                Console.Write("Write the submition date time(dd/mm/yy): ");
                string subDateTime = Console.ReadLine().Trim();
                Console.Write("Write the oral mark: ");
                string oralMark = Console.ReadLine().Trim();
                Console.Write("Write the total mark: ");
                string totalMark = Console.ReadLine().Trim();

                //Creates Assignment object and adds it to list
                School.AddAssignmentInList(new Assignment(title, description, subDateTime, oralMark, totalMark));

                if (onlyOneEntry)
                {
                    //Return to Assignment-Course matching
                    break;
                }
                else
                {
                    //Continue with next Student input or 'finish'
                    Console.Write("Write the title of the Assignment or 'finish': ");
                    title = Console.ReadLine();
                }
            }
            if (!onlyOneEntry)
            {
                Console.Clear();
            }
        }
        public override string ToString()
        {
            return $"{title} {description} {subDate.ToString("dd/MM/yyyy")} {oralMark} {totalMark}";
        }

    }
}
