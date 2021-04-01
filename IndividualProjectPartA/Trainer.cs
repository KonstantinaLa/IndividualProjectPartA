using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectPartA
{
    class Trainer
    {
        public string firstName { get; set; }
        public string lastName { get; set; }

        private string subject;
        public Trainer(string name, string lastName, string subject)
        {
            firstName = name;
            this.lastName = lastName;
            this.subject = subject;
        }
        public override string ToString()
        {
            return $"{firstName} {lastName} {subject}";
        }
        public static void addTrainers(bool onlyOneEntry)
        {
            string message;
            if (onlyOneEntry)
            {
                //executes if user chose to add extra trainer (in School.MatchtrainersCourses())
                message = "Write the fullname of the trainer: ";
            }
            else
            {
                Console.Clear();
                message = "Write the fullname of the trainer or 'finish': ";
            }

            Console.Write(message);
            string fullName = Console.ReadLine();

            while (fullName.ToUpper().Trim() != "FINISH")
            {
                //get trainer info
                string[] fullnameArray = fullName.Trim().Split(' ');
                string name = fullnameArray[0].ToUpper();
                string lastName = fullnameArray[1].ToUpper();

                Console.Write("Give me the subject: ");
                string subject = Console.ReadLine();
                subject = subject.Trim();

                //Creates Trainer object and adds it to list
                School.AddTrainerInList(new Trainer(name, lastName, subject));
              
                if (onlyOneEntry)
                {
                    //Return to Trainer-Course matching
                    break;
                }
                else
                {
                    //Continue with next Trainer input or 'finish'
                    Console.Write("Write the fullname of the trainer or 'finish': ");
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
