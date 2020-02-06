using NameDayLibrary;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameDay
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "nimet.csvsdfsfsfsd";
            string filepath = Path.Combine(Environment.CurrentDirectory, @"datafiles\", filename);
            DataReader dataReader = new DataReader();
            ArgumentValidation argumentValidation = new ArgumentValidation();

            //string date;
            string date = "30.11.";

            //Check that date argument that has been received is valid
            try
            {
                //date = args[0];
                date = argumentValidation.ValidateDate(date);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Couldn't recognize date.");
                Console.WriteLine("Try giving it in dd.mm. format.");
                Console.WriteLine("Press any key.");
                Console.ReadLine();
                throw new ArgumentException("Couldn't recognize date");
            }

            
            List<Person> celebrators = dataReader.GetNameDayPeople(date, filepath);

            Console.WriteLine($"The following people have name day in {date}:");

            foreach (Person p in celebrators)
            {
                Console.WriteLine($"{p.Name}");
            }

            Console.ReadLine();
        }
    }
}
