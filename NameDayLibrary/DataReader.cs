using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameDayLibrary
{
    public class DataReader
    {
        /// <summary>
        /// Get people who have name day at chosen date
        /// </summary>
        public List<Person> GetNameDayPeople(string date, string filepath)
        {
            List<Person> people = new List<Person>();

            List<string> lines = GetFileLines(filepath);

            foreach (string l in lines)
            {
                string[] entries = l.Split(';');

                if (entries[0] == date)
                {
                    Person person = new Person()
                    {
                        Date = entries[0],
                        Name = entries[1]
                    };

                    people.Add(person);
                }
            }


            return people;
        }
        /// <summary>
        /// Get list of strings based on lines in file that contains data
        /// </summary>
        public List<string> GetFileLines(string filepath)
        {
            List<string> lines = new List<string>();

            try
            {
                lines = File.ReadAllLines(filepath).ToList();
            }
            catch (Exception ex)
            {
                //Log
                throw new FileNotFoundException(ex.Message);

                //Not really sure what is preferred method here since i can't actually "handle" this exception
                //Console.writeline here and tell user that filepath is wrong?
                //Bounce exception back to program.cs and Console.writeline there?
                //Just Log and shut program down?
            }

            return lines;
        }

    }
}
