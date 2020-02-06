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
            string filename = "nimet.csv";
            string filepath = Path.Combine(Environment.CurrentDirectory, @"datafiles\", filename);
            DataReader dataReader = new DataReader();
            

            // --- Configurability of file names ---
            //Bring filename or path as an argument
            //if(args[1] != null && args[1].Length > 0)
            //{
            //    filename = args[1];
            //    //Or
            //    filepath = args[1];
            //}
            //Or
            //Read filename or path from txt.file
            //filepath = GetFileLines();
            //etc...
            // --- Configurability of file names ---

            string date;

            //Check that date argument that has been received is valid
            try
            {
                date = ArgumentValidation.ValidateDate(args[0]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Couldn't recognize date.");
                Console.WriteLine("Try giving it in dd.mm. format next time.");
                Console.WriteLine("For now let's continue and see if there's any people who have name day today.");
                Console.WriteLine("Press any key.");
                Console.ReadLine();

                DateTime dateTime = DateTime.UtcNow.Date;
                date = dateTime.ToString("d.M.");
            }

            List<Person> celebrators = dataReader.GetNameDayPeople(date, filepath);

            Console.WriteLine($"The following people have name day in {date}:");
            int i = 0;
            foreach (Person p in celebrators)
            {
                i++;
                Console.WriteLine($"{i}. {p.Name}");
            }

            Console.ReadLine();
        }
    }
}
